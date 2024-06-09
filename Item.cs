using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace rockpaperscisors
{
    internal class Item
    {
        private string _name {get; set; }

        public string DisplayName => _name;
        private List<Item> _isBiting {get; set;}
        private List<Item> _isLosing {get; set;}

        private BitmapImage _image { get; set; }

        public Item(string name, List<Item> isBiting, List<Item> isLosing, BitmapImage image)
        {
            this._name = name;
            this._isBiting = isBiting;
            this._isLosing = isLosing;
            this._image = image;
        }
        public Item(string name, BitmapImage image)
        {
            this._name = name;
            this._isBiting = new List<Item>();
            this._isLosing = new List<Item>();
            this._image = image;
        }
        public Item(string name){
            this._name = name;
            this._isBiting = new List<Item>();
            this._isLosing = new List<Item>();
            this._image = new BitmapImage();
        }
        public Item(){
            this._name = "Undefined";
            this._isBiting = new List<Item>();
            this._isLosing = new List<Item>();
            this._image = new BitmapImage();
        }

        public void AddIsBitingAndLosing(List<Item> isBiting, List<Item> isLosing)
        {
            this._isBiting = isBiting;
            this._isLosing = isLosing;
        }

        public string GetName()
        {
            return _name;
        }
        public List<Item> GetIsBiting()
        {
            return _isBiting;
        }
        public List<Item> GetIsLosing()
        {
            return _isLosing;
        }
        public BitmapImage GetImage()
        {
            return _image;
        }
        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetIsBiting(List<Item> isBiting)
        {
            this._isBiting = isBiting;
        }
        public void SetIsLosing(List<Item> isLosing)
        {
            this._isLosing = isLosing;
        }
        public void SetImage(BitmapImage image)
        {
            this._image = image;
        }

        public override string ToString()
        {
            return "Name: " + _name + "Is Biting: "  + _isBiting + "Is Losing: " + _isLosing;
        }

        public string CompareTo(Item item){
            if(item._name == this._name){
                return "Draw";
            }
            bool wins = _isBiting.Contains(item), loses = _isLosing.Contains(item);
            if(wins && loses){
                return "Error: Item defined as both losing and biting";
            }
            if(!wins && !loses){
                return "Error: Item not defined as either losing or biting"; 
            }
            if(wins){
                return "Win";
            }
            if(loses){
                return "Lose";
            }
            return "Error: Unknown error";
            
        }
    }
}
