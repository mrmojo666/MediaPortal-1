#region Copyright (C) 2005-2011 Team MediaPortal

// Copyright (C) 2005-2011 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Windows.Forms;

namespace Mediaportal.TV.Server.SetupTV.Dialogs
{
  public partial class FormSelectItem : Form
  {
    public FormSelectItem(string caption, string explanation, object[] items, string itemDisplayMember, object preselectedItem = null)
    {
      InitializeComponent();
      Text = caption;
      labelItems.Text = explanation;

      listBoxItems.DisplayMember = itemDisplayMember;
      listBoxItems.Items.AddRange(items);
      listBoxItems.SelectedItem = preselectedItem;
    }

    private void buttonOkay_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    public object Item
    {
      get
      {
        return listBoxItems.SelectedItem;
      }
    }
  }
}