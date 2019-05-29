using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenDataFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dlg.DefaultExt = ".txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                // Open document 
                string filename = dlg.FileName;
                this.txtFilePath.Text = filename;
            }
        }

        private void BtnEstimateVolume_Click(object sender, RoutedEventArgs e)
        {
            string path = Validator.ValidateFilePath(this.txtFilePath.Text);
            decimal gridCellSize = Validator.ValidateDecimal(this.txtGridCellSize.Text);
            decimal fluidContact = Converter.MetreToFeet(Validator.ValidateDecimal(this.txtFluidContact.Text));
            decimal horizonDepth = Converter.MetreToFeet(Validator.ValidateDecimal(this.txtHorizonDepth.Text));

            DataProcessor dataProcessor = new DataProcessor();
            Dictionary<int, string> volumes = dataProcessor.FindVolume(path, horizonDepth, gridCellSize, fluidContact);

            this.txtVolCubicFeet.Text = volumes[0];
            this.txtVolCubicMetre.Text = volumes[1];
            this.txtVolBarrel.Text = volumes[2];
        }
    }
}
