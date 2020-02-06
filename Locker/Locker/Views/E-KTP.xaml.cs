using Locker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class E_KTP : ContentPage
    {
        E_KTPDataStore e_ktpDataStore = new E_KTPDataStore();
        public E_KTP()
        {
            InitializeComponent();
        }
        async void Search_Clicked(object sender, EventArgs e)
        {
            var nik = this.entryNIK.Text;
            var searchingResult = await e_ktpDataStore.GetItemsAsync(nik, true);
            if(searchingResult != null)
            {
                this.labelFullName.Text = searchingResult.NAMA_LGKP;
                this.labelNO_KK.Text = searchingResult.NO_KK.ToString();
                this.labelNIK.Text = searchingResult.NIK.ToString();
                this.labelKAB_NAME.Text = searchingResult.KAB_NAME;
                this.labelNO_RW.Text = searchingResult.NO_RW?.ToString();
                this.labelKEC_NAME.Text = searchingResult.KEC_NAME;
                this.labelJENIS_PKRJN.Text = searchingResult.JENIS_PKRJN;
                this.labelNO_RT.Text = searchingResult.NO_RT?.ToString();
                this.labelNO_KEL.Text = searchingResult.NO_KEL?.ToString();
                this.labelALAMAT.Text = searchingResult.ALAMAT;
                this.labelNO_KEC.Text = searchingResult.NO_KEC?.ToString();
                this.labelTMPT_LHR.Text = searchingResult.TMPT_LHR;
                this.labelSTATUS_KAWIN.Text = searchingResult.STATUS_KAWIN;
                this.labelNO_PROP.Text = searchingResult.NO_PROP?.ToString();
                this.labelNAMA_LGKP_IBU.Text = searchingResult.NAMA_LGKP_IBU;
                this.labelPROP_NAME.Text = searchingResult.PROP_NAME;
                this.labelNO_KAB.Text = searchingResult.KAB_NAME;
                this.labelKEL_NAME.Text = searchingResult.KEL_NAME;
                this.labelJENIS_KLMIN.Text = searchingResult.JENIS_KLMIN;
                this.labelTGL_LHR.Text = searchingResult.TGL_LHR;

                var duration = TimeSpan.FromSeconds(0.5);
                Vibration.Vibrate(duration);

            }
            else
            {
                //this.activityIndicatorSearchDataEktp.IsEnabled = true;
                //this.activityIndicatorSearchDataEktp.IsRunning = true;
                //this.activityIndicatorSearchDataEktp.IsVisible = true;

            }
        }
        void Clear_Clicked(object sender, EventArgs e)
        {
            this.entryNIK.Text = "";
        }
    }
}