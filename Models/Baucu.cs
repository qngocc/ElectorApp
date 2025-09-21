using System;

namespace ElectorApp.Models
{
    internal class Baucu
    {
        public int ID { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public DateTime ngaybd { get; set; }
        public DateTime ngaykt { get; set; }
        public bool ketthuc { get; set; }

        public int coTheChon {  get; set; }
        public HashSet<String> luachon { get; set; }

        int soluuchon = 0;

        public Baucu()
        {
            // Constructor mac dinh
        }

        public Baucu(int id, string ten, string mota,DateTime ngaybd, DateTime ngaykt, HashSet<String> luachon)
        {
            ID = id;
            this.ten = ten;
            this.mota = mota;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
            this.ketthuc = false;
            this.luachon = luachon;
            this.soluuchon = luachon.Count;
        }

    }
}