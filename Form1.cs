using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace working_with_files_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Equipment temp = new Equipment(tbName.Text, (int)Convert.ToInt32(tbPrice.Text));
                Program.addEquipment(temp);

                ListViewItem item = new ListViewItem(temp.EquipmentName.ToString());
                item.SubItems.Add(temp.EquipmentPrice.ToString());
                listViewEquipment.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Input Data!", ex.Message);
            }
            finally
            {
                tbName.Clear();
                tbPrice.Clear();
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            string temp;
            foreach (ListViewItem itm in listViewEquipment.Items)
            {
                if (itm.Selected == true)
                {
                    temp = itm.Text;
                    itm.Remove();
                    Program.removeEquipment(temp);
                }
            }   
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Program.Save();
            MessageBox.Show("Saved!");
            foreach (Equipment eachItem in Program.equipmentList)
            {
                ListViewItem item = new ListViewItem(eachItem.EquipmentName.ToString());
                item.SubItems.Add(eachItem.EquipmentPrice.ToString());
                listViewEquipment.Items.Remove(item);
            }
            //listViewEquipment.Clear();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            Program.Load();
            
            foreach(Equipment eachItem in Program.equipmentList)
            {
                ListViewItem item = new ListViewItem(eachItem.EquipmentName.ToString());
                item.SubItems.Add(eachItem.EquipmentPrice.ToString());
                listViewEquipment.Items.Add(item);
            }
        }
    }
}
