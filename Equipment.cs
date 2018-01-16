using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace working_with_files_2
{
    [Serializable]
    class Equipment
    {
        private string equipmentName;
        private int equipmentPrice;

        public Equipment (string _name, int _price)
        {
            equipmentName = _name;
            equipmentPrice = _price;
        }

        public string EquipmentName { get => equipmentName; set => equipmentName = value; }
        public int EquipmentPrice { get => equipmentPrice; set => equipmentPrice = value; }
    }
}
