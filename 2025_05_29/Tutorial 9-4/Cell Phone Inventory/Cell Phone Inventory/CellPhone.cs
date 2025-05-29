using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Inventory
{
    class CellPhone
    {
        // 欄位：儲存手機品牌名稱
        private string _brand;

        // 欄位：儲存手機型號名稱
        private string _model;

        // 欄位：儲存手機的零售價格（以十進位表示，避免浮點誤差）
        private decimal _price;

        // 建構子：初始化 CellPhone 物件，將品牌、型號設為空字串，價格設為 0
        public CellPhone()
        {
            _brand = "";
            _model = "";
            _price = 0m;
        }

        // 品牌屬性：取得或設定手機品牌名稱
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        // 型號屬性：取得或設定手機型號名稱
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        // 價格屬性：取得或設定手機的零售價格
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
