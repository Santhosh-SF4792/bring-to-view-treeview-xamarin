using Syncfusion.XForms.TreeView;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TreeViewXamarin
{
    public class TreeViewBehavior : Behavior<ContentPage>
    {
        #region Fields

        private SfTreeView TreeView;
        private Button Button;
        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            TreeView = bindable.FindByName<SfTreeView>("treeView");
            Button = bindable.FindByName<Button>("bringIntoView");
            Button.Clicked += BringIntoView_Clicked;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            Button.Clicked -= BringIntoView_Clicked;
            Button = null;
            TreeView = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region CallBack
        private void BringIntoView_Clicked(object sender, EventArgs e)
        {
            var viewModel = (sender as Button).BindingContext as FileManagerViewModel;
            var count = viewModel.ImageNodeInfo.Count;
            var data = viewModel.ImageNodeInfo[count - 1];
            TreeView.BringIntoView(data);
        }
        #endregion
    }
}
