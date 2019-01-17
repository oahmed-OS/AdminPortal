using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AdminPortal.Android.Views.Dialogs
{
    public class ErrorDialog : Dialog
    {
        private String errLabel;
        private String errDesc;
        private Button errBtn;

        public ErrorDialog(Activity activity)
            : base(activity) { }

        public ErrorDialog(Activity activity, String errLabel)
            : base(activity) { this.errLabel = errLabel; }

        public ErrorDialog(Activity activity, String errLabel, String errDesc)
            : base(activity)
        {
            this.errLabel = errLabel;
            this.errDesc = errDesc;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_error);

            TextView errLabelView = FindViewById<TextView>(Resource.Id.error_label);
            TextView errDescView = FindViewById<TextView>(Resource.Id.error_description);

            if (!String.IsNullOrEmpty(errLabel))
                errLabelView.Text = errLabel;


            if (!String.IsNullOrEmpty(errDesc))
                errDescView.Text = errDesc;

            errBtn = FindViewById<Button>(Resource.Id.error_btn);

            errBtn.Click += ErrBtn_Click;

        }

        private void ErrBtn_Click(object sender, EventArgs e)
        {
            this.Dismiss();
        }
    }
}