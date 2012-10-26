﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using Mediaportal.TV.Server.TVControl.Events;
using Mediaportal.TV.Server.TVControl.Interfaces.Events;
using Mediaportal.TV.Server.TVControl.Interfaces.Services;
using Mediaportal.TV.Server.TVLibrary.Interfaces.CiMenu;
using MediaPortal.Common.Utils;

namespace Mediaportal.TV.Server.TVLibrary.Services
{
  class Subscriber
  {
    public string UserName { get; set; }
    public IServerEventCallback ServerEventCallback { get; set; }
  }

  [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
  public class EventService : IEventService, IDisposable
  {
  

    private static readonly IDictionary<string, Subscriber> _subscribers = new ConcurrentDictionary<string, Subscriber>();
    private static readonly object _subscribersLock = new object();

    public delegate void UserDisconnectedFromServiceDelegate(string userName);
    public static UserDisconnectedFromServiceDelegate UserDisconnectedFromService;

    #region IDisposable

    ~EventService()
    {
      Dispose();
    }

    public static void CleanUp ()
    {
      lock (_subscribersLock)
      {
        foreach (Subscriber subscriber in _subscribers.Values)
        {
          IServerEventCallback eventCallback = subscriber.ServerEventCallback;
          var obj = eventCallback as ICommunicationObject;
          if (obj != null)
          {
            obj.Abort();
            obj.Close();            
          }
        }
        _subscribers.Clear();
      }
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <filterpriority>2</filterpriority>
    public void Dispose()
    {
      Log.DebugFormat("EventService.Dispose");
    }

    #endregion

    public void Subscribe(string username)
    {
      Log.DebugFormat("EventService.Subscribe user:{0}", username);
      bool alreadySubscribed;
      lock (_subscribersLock)
      {
        alreadySubscribed = _subscribers.ContainsKey(username);
      }

      if (!alreadySubscribed)
      {
        try
        {
          var eventCallback = OperationContext.Current.GetCallbackChannel<IServerEventCallback>();

          var obj = eventCallback as ICommunicationObject;
          if (obj != null)
          {
            obj.Faulted += EventService_Faulted;
            obj.Closed += EventService_Closed;
          }
          var subscriber = new Subscriber { UserName = username, ServerEventCallback = eventCallback };
          lock (_subscribersLock)
          {
            _subscribers[username] = subscriber;
          }
          
        }
        catch (Exception e)
        {
          Log.ErrorFormat("EventService.Subscribe failed for user '{0}' with ex '{1}'", username, e);
        }
      }      
    }

    public void Unsubscribe(string username)
    {
      Log.DebugFormat("EventService.Unsubscribe user:{0}", username);
      Subscriber subscriber;
      bool found;
      lock (_subscribersLock)
      {
        found = _subscribers.TryGetValue(username, out subscriber);
      }
      if (found)
      {        
        FireUserDisconnectedFromService(subscriber.ServerEventCallback);
      }
    }

    private static void EventService_Faulted(object sender, EventArgs e)
    {
      Log.DebugFormat("EventService.EventService_Faulted");
      FireUserDisconnectedFromService(sender as IServerEventCallback);
    }

    private static void EventService_Closed(object sender, EventArgs e)
    {
      Log.DebugFormat("EventService.EventService_Closed");
      FireUserDisconnectedFromService(sender as IServerEventCallback);
    }

    private static void FireUserDisconnectedFromService(IServerEventCallback eventCallback)
    {      
      if (eventCallback != null)
      {
        {
          Subscriber subscriber;
          lock (_subscribersLock)
          {
            subscriber = _subscribers.Values.FirstOrDefault(c => c.ServerEventCallback == eventCallback);
          }
          if (subscriber != null)
          {
            string username = subscriber.UserName;

            var obj = eventCallback as ICommunicationObject;
            if (obj != null)
            {
              obj.Faulted -= EventService_Faulted;
              obj.Closed -= EventService_Closed;
              obj.Abort();
              obj.Close();
            }

            if (UserDisconnectedFromService != null)
            {
              UserDisconnectedFromService(username);
            }
            lock (_subscribersLock)
            {
              if (_subscribers.ContainsKey(username))
              {
                Log.DebugFormat("EventService.FireUserDisconnectedFromService user:{0}", username);
                _subscribers.Remove(username);
              }
            }
          }
        }        
      }
    }    

    private static bool IsConnectionReady(ICommunicationObject callback)
    {
      bool connectionReady = callback != null && (callback.State == CommunicationState.Opened);
      return connectionReady;
    }

    #region public static methods

    public static void CallbackTvServerEvent(string username, TvServerEventArgs eventArgs)
    {
      Subscriber subscriber;
      bool userFound;
      lock (_subscribersLock)
      {
        userFound = _subscribers.TryGetValue(username, out subscriber);
      }
      try
      {
        if (userFound)
        {
          if (IsConnectionReady(subscriber.ServerEventCallback as ICommunicationObject))
          {
            IServerEventCallback callback = subscriber.ServerEventCallback;
            ThreadPool.QueueUserWorkItem(
              delegate
                {
                  try
                  {
                    callback.BeginOnCallbackTvServerEvent(eventArgs, delegate(IAsyncResult result)
                    {
                      try
                      {
                        callback.EndOnCallbackTvServerEvent(result);
                      }
                      catch (Exception ex)
                      {
                        Log.ErrorFormat("EventService.EndOnCallbackTvServerEvent failed for user:{0} ex:{1}", username, ex);
                      }
                    },
                    null);
                  }
                  catch (Exception ex)
                  {
                    Log.ErrorFormat("EventService.BeginOnCallbackTvServerEvent failed for user:{0} ex:{1}", username, ex);        
                  }
                }
              );             
          }
          else
          {
            FireUserDisconnectedFromService(subscriber.ServerEventCallback);
          }
        }    
      }
      catch (Exception ex)
      {
        Log.ErrorFormat("EventService.CallbackTvServerEvent failed for user:{0} ex:{1}", username, ex);
      }      
    }

    public static void CallbackCiMenuEvent(string username, CiMenu eventArgs)
    {
      Subscriber subscriber;
      bool userFound;
      lock (_subscribersLock)
      {
        userFound = _subscribers.TryGetValue(username, out subscriber);
      }
     
      try
      {
        if (userFound)
        {
          if (IsConnectionReady(subscriber.ServerEventCallback as ICommunicationObject))
          {
            var callback = subscriber.ServerEventCallback;            
            ThreadPool.QueueUserWorkItem(
              delegate
              {
                try
                {
                  callback.BeginOnCallbackCiMenuEvent(eventArgs,
                                                      delegate(IAsyncResult result)
                                                        {
                                                          try
                                                          {
                                                            callback.EndOnCallbackCiMenuEvent(result);
                                                          }
                                                          catch (Exception ex)
                                                          {
                                                            Log.ErrorFormat(
                                                              "EventService.EndOnCallbackCiMenuEvent failed for user:{0} ex:{1}",
                                                              username, ex);
                                                          }
                                                        },
                                                      null);                
                }
                catch (Exception ex)
                {                  
                  Log.ErrorFormat("EventService.BeginOnCallbackCiMenuEvent failed for user:{0} ex:{1}", username, ex);
                }
              }
             ); 
          }
          else
          {
            FireUserDisconnectedFromService(subscriber.ServerEventCallback);
          }
        }
      }
      catch (Exception ex)
      {
        Log.ErrorFormat("EventService.CallbackCiMenuEvent failed for user:{0} ex:{1}", username, ex);
      }   
    }

    public static bool CallbackRequestHeartbeat(string username)
    {
      bool heartbeatSent = false;
      Subscriber subscriber;
      bool userFound;
      lock (_subscribersLock)
      {
        userFound = _subscribers.TryGetValue(username, out subscriber);
      }

      try
      {
        if (userFound)
        {
          if (IsConnectionReady(subscriber.ServerEventCallback as ICommunicationObject))
          {
            var callback = subscriber.ServerEventCallback;
            ThreadPool.QueueUserWorkItem(
              delegate
              {
                try
                {
                  callback.BeginOnCallbackHeartBeatEvent(
                                                      delegate(IAsyncResult result)
                                                      {
                                                        try
                                                        {
                                                          callback.EndOnCallbackHeartBeatEvent(result);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                          Log.ErrorFormat(
                                                            "EventService.EndOnCallbackHeartBeatEvent failed for user:{0} ex:{1}",
                                                            username, ex);
                                                        }
                                                      },
                                                      null);
                }
                catch (Exception ex)
                {
                  Log.ErrorFormat("EventService.BeginOnCallbackHeartBeatEvent failed for user:{0} ex:{1}", username, ex);
                }
              }
             ); 

            heartbeatSent = true;
          }
          else
          {
            FireUserDisconnectedFromService(subscriber.ServerEventCallback);
          }
        }
      }
      catch (Exception ex)
      {
        Log.ErrorFormat("EventService.CallbackRequestHeartbeat failed for user:{0} ex:{1}", username, ex);                
      }
      
      return heartbeatSent;
    }

    #endregion

    
  }
}
