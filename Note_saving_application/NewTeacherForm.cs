using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Note_saving_application
{
    public partial class NewTeacherForm : Form
    {
        public NewTeacherForm()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void NewTeacherForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_note_savingDataSet.TBL_LESSON' table. You can move, or remove it, as needed.
            this.tBL_LESSONTableAdapter.Fill(this.db_note_savingDataSet.TBL_LESSON);

        }
    }
}
