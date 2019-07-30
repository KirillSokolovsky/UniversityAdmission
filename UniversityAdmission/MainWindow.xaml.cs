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
using UniversityAdmission.Models;
using UniversityAdmission.Parsers;

namespace UniversityAdmission
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainModel Model = new MainModel();

        public MainWindow()
        {
            //http://technolog.edu.ru/component/k2/item/3666
            //http://abiturient.pharminnotech.com/spiski-postupausih/spiski-s-vydeleniem
            InitializeComponent();

            DataContext = Model;

            InitUnivers();
        }

        public void InitUnivers()
        {
            var uniModels = new List<UniversityModel>();

            var u1p = new SpbUniver1Parser();
            uniModels.Add(u1p.GetUniversityModel());

            foreach (var uModel in uniModels)
            {
                foreach (var sModel in uModel.Specialities)
                {
                    sModel.Abiturients = sModel.Abiturients.OrderByDescending(a => a.Ege)
                        .ToList();

                    var c = 0;
                    sModel.Abiturients.ForEach(a => a.Order = ++c);

                    var filterOrder = sModel.Abiturients.FirstOrDefault(a => a.Fio.StartsWith(Model.Filter));
                    sModel.FilterNumber = filterOrder.Order;

                    var sogl = sModel.Abiturients.Where(a =>
                        a.Order < sModel.FilterNumber
                        && a.IsImmidiate
                        && !a.AnotherDirection)
                        .Count();

                    sModel.Soglasen = sogl;
                }

                Model.Universities.Add(uModel);
            }
        }
    }
}
