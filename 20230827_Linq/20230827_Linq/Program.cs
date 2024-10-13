using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace _20230827_Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Linq sorgulama yöntemi .NET Framework 3.5 ile birlikte gelen bir teknolojidir
            //Linq yöntemi ile koleksiyonlar içerisindeki verileri filtreleyebilir , sıralayabilir , gruplandırabiliriz

            List<string> sehirler = new List<string>()
            {
                        "İstanbul","İzmir","Ankara","Manisa","Adıyaman","Edirne","Bursa","Antalya",
                "Mersin","Tokat"
            };


            //Koleksiyon içerisindeki verileri linq sorgusu ile çekelim
            var liste = from s
                        in sehirler
                        select s;
            //from=>seçilen koleksiyon sorgu işlemleri esnasında takma isim vermemizi sağlar.Linq sorgulamaları esnasında takma isim verme mecburiyeti vardır
            //in=> linq sorgulama işlemlerinde hangi koleksiyon baz alınacak ise o koleksiyonu seçmemizi sağlar
            //select=> sorgulama işlemleri tamamlandıktan sonra geriye hangi veriyi döndüreceğimizi belirtir
            //Sorgulama işlemi tamamlandıktan sonra IEnumerable<?> tipinde bir koleksiyon döndürür
            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }

            #region OrderBy
            //Linq sorgulama yöntemi ile koleksiyonlar içerisindeki verileri küçükten büyüğe  sıralama işlemi yapmamızı sağlar
            var kbSehirler = from s
                             in sehirler
                             orderby s ascending
                             select s;
            //orderby=> koleksiyon içerisindeki verileri sıralama işlemi yapmamızı sağlar
            //orderby komutundan sonra hangi veriye sıralama işlemi uygulyacak isek onu belirtmemiz gerekmektedir.
            //Sonrasında ascending ,descending ifadeleri ile sıralama yaptırabiliriz
            //ascending=> küçükten büyüğe
            //descending=>büyükten küçüğe sıralama işlemi yaptırır
            //Select komutundan önce kullanılması gerekir
            //Geriye IOrderedEnumerable<?> tipinde veri döndürür

            Console.WriteLine();
            Console.WriteLine("OrderBy\n---------------");
            foreach (var item in kbSehirler)
            {
                Console.WriteLine(item);
            }


            #endregion

            #region OrderBy Descending
            var bkSehirler = from s
                             in sehirler
                             orderby s descending
                             select s;
            Console.WriteLine("\n----\nOrderBy Descending\n----------\n");
            foreach (var item in bkSehirler)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region Where
            //Linq sorgulama işlemi esnasında baz alınan koleksiyon içerisindeki verileri filtrelemek için kullanılır
            //Filtreleme işlemini "where" komutu ile yaparız
            //Where komutunu orderby ve select komutlarından önce kullanmalıyız
            var fSehirler = from s
                            in sehirler
                            where s[0].ToString().ToLower() == "a"
                            orderby s ascending
                            select s;
            Console.WriteLine("\n----\nWhere - A ile başlayan şehirler\n----------\n");
            foreach (var item in fSehirler)
            {
                Console.WriteLine(item);
            }

            #endregion

            Console.ReadKey();
        }
    }
}
