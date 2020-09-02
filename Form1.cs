using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xwing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //this.Name = "form";
            //Form wholeForm = this;
            //FormStyling.StylingGeneral.wholeForm = wholeForm;

            //InitializeComponent();
            //FormStyling.StylingGeneral.FormAttrs();
            //FactionChoiceScreen.FactionChoiceScreenStyling.GetElements();
            //FactionChoiceScreen.PopulateFactionChoices.GetFactions();

            this.Name = "form";
            Form wholeForm = this;
            Styling.WholeForm.TheForm = wholeForm;

            InitializeComponent();
            Styling.WholeForm.GetElements();
            Styling.StartPage.GetElements();
            //Styling.StartPage.GetElements();
            //FactionChoiceScreen.FactionChoiceScreenStyling.GetElements();
            //FactionChoiceScreen.PopulateFactionChoices.GetFactions();

        }
    }
}
