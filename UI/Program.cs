using MTControl;
using System;
using System.Threading;
using System.Windows.Forms;

namespace FormUI
{
    static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string appName = "PM_QUAN_LY_VAT_TU_2022";
            bool createdNew;

            mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                ProcessUtils.SetFocusToPreviousInstance(appName);
                return;
            }
            RegisterLicenseAspose();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MCommon.SetSkins();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            //Chỉ định ngữ cảnh của project là ViệtNam
            //Gán ngữ cảnh cho control
            MTControl.MCommon.GroupSeparator = ".";
            MTControl.MCommon.DecimalSeparator = ",";

            System.Globalization.CultureInfo oCultureInfo = MCommon.GetCurrentCultureInfo(); ;

            System.Threading.Thread.CurrentThread.CurrentUICulture = oCultureInfo;
            Thread.CurrentThread.CurrentCulture = oCultureInfo;
            Thread.CurrentThread.CurrentUICulture = oCultureInfo;


            MTControl.MCommon.Culture = oCultureInfo;
            MTControl.MCommon.AssemblyNameFormUI = "FormUI";
            MTControl.MCommon.AssemblyNameModels = "MT.Data";
            MTControl.MCommon.AssemblyNameEnum = "MT.Data";

            MTControl.MCommon.ResourceComboLooUp = "FormUI.ComboResource";

            Application.Run(new frmStarting());
        }

       
        /// <summary>
        /// Add license Aspose
        /// </summary>
        static void RegisterLicenseAspose()
        {

            try
            {
                Aspose.Words.License license = new Aspose.Words.License();
                license.SetLicense(@"License\Aspose.Total.lic");
            }
            catch
            {
            }
        }

    }
}
