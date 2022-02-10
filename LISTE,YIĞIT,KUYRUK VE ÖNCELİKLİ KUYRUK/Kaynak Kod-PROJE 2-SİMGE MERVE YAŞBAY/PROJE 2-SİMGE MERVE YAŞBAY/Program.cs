using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE_2_SİMGE_MERVE_YAŞBAY
{
    class MusteriSinifi
    {
        public string MusteriAdi;
        public int UrunSayisi;
        public MusteriSinifi(string müsteriadi, int ürünsayisi)
        {
            this.MusteriAdi = müsteriadi;
            this.UrunSayisi = ürünsayisi;

        }
    }
    class StackX   //STACK sınıfı
    {
        private int maxsize;
        private MusteriSinifi[] stackarray;
        private int top;
        public StackX(int s)
        {
            maxsize = s;
            stackarray = new MusteriSinifi[maxsize];
            top = -1;
        }
        public void push(MusteriSinifi j)
        {
            stackarray[++top] = j;
        }
        public MusteriSinifi pop()
        {
            return stackarray[top--];
        }
        public MusteriSinifi peek()
        {
            return stackarray[top];
        }
        public Boolean isEmpty()
        {
            return (top == -1);
        }
        public Boolean isFull()
        {
            return (top == maxsize - 1);
        }
    }
    class Queue //KUYRUK sınıfı
    {
        private int maxsize;
        private MusteriSinifi[] queArray;
        private int front;
        private int rear;
        private int nitems;
        public Queue(int s) //constructor
        {
            maxsize = s;
            queArray = new MusteriSinifi[maxsize];
            front = 0;
            rear = -1;
            nitems = 0;
        }
        public void insert(MusteriSinifi j) //itemi kuyruğun arkasına eklemek
        {
            if (rear == maxsize - 1)
            {
                rear = -1;
            }
            queArray[++rear] = j;
            nitems++; //item sayısı arttır
        }
        public MusteriSinifi remove() //kuyruğun başındaki itemi çıkarmak
        {
            MusteriSinifi temp = queArray[front++];
            if (front == maxsize)
            {
                front = 0;

            }
            nitems--; //item sayısı azalt
            return temp;
        }
        public MusteriSinifi peekFront() //ulaşma 
        {
            return queArray[front];
        }
        public Boolean isEmpty()
        {
            return (nitems == 0);
        }
        public Boolean isFull()
        {
            return (nitems == maxsize);
        }
        public int size() //item sayısı
        {
            return nitems;
        }
    }
    class OncelikliQueue //ONCELİKLİ KUYRUK sınıfı
    {
        public List<MusteriSinifi> oncelikliqueuelist;
        public OncelikliQueue() //constructor
        {
            oncelikliqueuelist = new List<MusteriSinifi>();
        }
        public void ekle(MusteriSinifi j)
        {
            oncelikliqueuelist.Add(j);

        }
        public MusteriSinifi büyüktenküçüğesil() //öncelikli kuyrukta büyükten küçüğe sıralaması için gerekli method
        {
            MusteriSinifi max = oncelikliqueuelist.ElementAt(0); //ilk elemanı max alıyor
            int maxindex = 0;
            for (int i = 1; i < oncelikliqueuelist.Count; ++i) //burada listedeki bütün elemanları karşılaştıracak
            {
                if (oncelikliqueuelist.ElementAt(i).UrunSayisi > max.UrunSayisi) //gelen eleman öncekinden büyük ise buraya girip max değere atıyor
                {
                    max = oncelikliqueuelist.ElementAt(i);
                    maxindex = i;
                }
            }
            oncelikliqueuelist.RemoveAt(maxindex); //max değer hangi indeksde ise o indeksdeki elemanı çıkartıyor ve döndürüyor
            return max;
        }
        public MusteriSinifi kucuktenbüyüğesil() //öncelikli kuyrukta küçükten büyüğe sıralaması için gerekli method
        {
            MusteriSinifi min = oncelikliqueuelist.ElementAt(0); //ilk elemanı min alıyor
            int minindex = 0;
            for (int j = 1; j < oncelikliqueuelist.Count; ++j) //listedeki bütün elemanları karşılaştıracak
            {
                if (oncelikliqueuelist.ElementAt(j).UrunSayisi < min.UrunSayisi) //gelen eleman öncekinden küçük ise buraya girip min değere atayacak
                {
                    min = oncelikliqueuelist.ElementAt(j);
                    minindex = j;
                }
            }
            oncelikliqueuelist.RemoveAt(minindex); //min değer hangi indeksde ise o indeksdeki elemanı çıkartıyor ve döndürüyor
            return min;
        }
        public Boolean bosMu()
        {
            return oncelikliqueuelist.Count == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] MüşteriAdı = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };

            int[] ÜrünSayısı = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };
            List<int> genlistboyutlari = new List<int>(); //genericlistboyutlarını saklamak için liste
            void RandomSayıOluştur(string[] müsterilistesi, int[] ürünlistesi)  //genericlist boyutları için gerekli random sayıları üretip bu sayıları saklayan fonksiyon yazdım
            {

                Random rnd = new Random();
                int nesnesayisi = müsterilistesi.Length;   //random sayıların toplamı nesne sayısı kadar olmalı
                while (nesnesayisi > 0 & nesnesayisi <= nesnesayisi)  //nesne sayısı 0 lanana kadar devam edecek
                {
                    int sayi = rnd.Next(1, 6);
                    nesnesayisi = nesnesayisi - sayi;  //random sayı ürettikten sonra nesne sayısından çıkartıyoruz
                    if (nesnesayisi >= 0)   //0 dan büyükse doğru ilerliyoruzdur
                    {
                        genlistboyutlari.Add(sayi);  //random sayıyı bir listeye atıyoruz
                    }
                    while (nesnesayisi < 0)    //nesne sayısı negatif olmaması gerek bu yüzden burada nesne sayısını sıfırlayana kadar tekrar random sayılar üretiyoruz
                    {
                        nesnesayisi = nesnesayisi + sayi;
                        sayi = rnd.Next(1, 6);
                        nesnesayisi = nesnesayisi - sayi;
                        if (nesnesayisi >= 0)
                        {
                            genlistboyutlari.Add(sayi);

                        }
                    }
                }

            }
            RandomSayıOluştur(MüşteriAdı, ÜrünSayısı);  //fonksiyonu verilen listeler için çağırdım
            
            ArrayList arrayliste = new ArrayList();
            int sayac = 0;
            MusteriSinifi musterisinifi;
            List<MusteriSinifi> genericliste;
            while (sayac < MüşteriAdı.Length)    //müşteriler bitene kadar genericlist boyutlarına göre müşterileri gruplandırıp array listeye ekliyoruz
            {
                for (int j = 0; j < genlistboyutlari.Count; j++)
                {
                    genericliste = new List<MusteriSinifi>();
                    int genericlisteLength = (genlistboyutlari)[j];

                    for (int i = 0; i < genericlisteLength; i++)
                    {

                        musterisinifi = new MusteriSinifi(MüşteriAdı[sayac], ÜrünSayısı[sayac]);
                        genericliste.Add(musterisinifi);
                        sayac++;
                        if (sayac == MüşteriAdı.Length)
                            break;

                    }
                    arrayliste.Add(genericliste);


                }


            }
            foreach (List<MusteriSinifi> item in arrayliste)  //yazdırma
            {
                foreach (MusteriSinifi item1 in item)
                {

                    Console.WriteLine("Müşteri Adı:\t" + item1.MusteriAdi + "\t Ürün Sayısı: " + item1.UrunSayisi);

                }
                Console.WriteLine();
            }
            double listesayisi = arrayliste.Count;  //arrayliste sayısı
            Console.WriteLine("ArrayListe sayısı : " + listesayisi);
            Console.WriteLine("Listelerin Ortalama Eleman Sayısı: " + (MüşteriAdı.Length / listesayisi)); //Her arrayde ortalama eleman sayısı
            Console.WriteLine();
            


            //-----------------------------YIĞIT CLASSINI ÇAĞIRIP YAZDIRMA--------------------------//

            Console.WriteLine("Yığıt Yazımı :");
            StackX stack = new StackX(MüşteriAdı.Length);
            foreach (List<MusteriSinifi> a in arrayliste) //arraydeki bilgilerimizi yığıta ekliyoruz
            {
                foreach (MusteriSinifi b in a)
                {
                    stack.push(b);
                }

            }
            while (!stack.isEmpty())  //yığıt bitene kadar yığıttaki elemanları yazdırıyoruz
            {
                MusteriSinifi value = stack.pop();
                Console.WriteLine("Müşteri Adı:\t " + value.MusteriAdi + "\t Ürün Sayısı: " + value.UrunSayisi);
            }
            
            Console.WriteLine();
            //----------------------------------------------------------------------------------------//


            //--------------------------------KUYRUK CLASSINI ÇAĞIRIP YAZDIRMA------------------------//
            Console.WriteLine("Kuyruk Yazımı:");
            Queue theQueue = new Queue(MüşteriAdı.Length);
            Queue theQueuekopya = new Queue(MüşteriAdı.Length); //Ortalama işlem süresi bulup yazdırma için kopya bir Queue tanımladım
            foreach (List<MusteriSinifi> c in arrayliste) //arraydaki bilgilerimizi kuyruğa ekliyoruz
            {
                foreach (MusteriSinifi d in c)
                {
                    theQueue.insert(d);
                    theQueuekopya.insert(d);
                }
            }
            while (!theQueue.isEmpty()) //bilgileri çıkartıp yazdırma
            {
                MusteriSinifi bilgiler = theQueue.remove();
                Console.WriteLine("Müşteri Adı:\t" + bilgiler.MusteriAdi + "\t Ürün Sayısı: " + bilgiler.UrunSayisi);
            }
            
            Console.WriteLine();

            //---------------------------------------------------------------------------------------//

            //-------------------ÖNCELİKLİ KUYRUK İLE SIRALAYIP YAZDIRMA İŞLEMLERİ---------------------//

            OncelikliQueue onceliklikuyrukbuyuktenkucuge = new OncelikliQueue(); //büyükten küçüğe kuyruk yapısı
            OncelikliQueue onceliklikuyrukkucuktenbuyuge = new OncelikliQueue(); //küçükten büyüğe kuyruk yapısı
            OncelikliQueue onceliklikuyrukkopya = new OncelikliQueue();
            foreach (List<MusteriSinifi> e in arrayliste)
            {
                foreach (MusteriSinifi f in e)
                {
                    onceliklikuyrukbuyuktenkucuge.ekle(f);  //arraydaki müşteri bilgilerini öncelikli kuyruklara atıyor
                    onceliklikuyrukkucuktenbuyuge.ekle(f);

                }
            }
            Console.WriteLine("Öncelikli Kuyruk ile Büyükten Küçüğe Sıralama:");
            while (!onceliklikuyrukbuyuktenkucuge.bosMu()) //öncelikli kuyruktaki elemanlar bitene kadar devam ediyor
            {
                MusteriSinifi degerler = onceliklikuyrukbuyuktenkucuge.büyüktenküçüğesil();    //öncelikli kuyruktaki bütün elemanları karşılaştırıp büyükten küçüğe sıralıyor
                onceliklikuyrukkopya.ekle(degerler);
                Console.WriteLine("Müşteri Adı:\t" + degerler.MusteriAdi + "\t Ürün Sayısı: " + degerler.UrunSayisi);

            }
            
            Console.WriteLine();
            Console.WriteLine("Öncelikli Kuyruk ile Küçükten Büyüğe Sıralama:");
            while (!onceliklikuyrukkucuktenbuyuge.bosMu()) //kuyruktaki elemanlar bitene kadar devam ediyor
            {
                MusteriSinifi degerler = onceliklikuyrukkucuktenbuyuge.kucuktenbüyüğesil(); //kuyruktaki bütün elemanları karşılaştırıp küçükten büyüğe sıralıyor
                Console.WriteLine("Müşteri Adı:\t" + degerler.MusteriAdi + "\t Ürün Sayısı: " + degerler.UrunSayisi);
            }
            

            //------------------------------------------------------------------------------------------//
            //-------------------------------İşlem Süresi Yazdırma ve Ortalama İşlem Süresi Bulma-------------//
            double tekkasaiçintoplamişlemsüresi1 = 0;
            double müşteriişlemsüresi1 = 0;
            Console.WriteLine();
            Console.WriteLine("Kuyruk Kullanarak Hesaplanan İşlem Süreleri :");
            while (!theQueuekopya.isEmpty())
            {
                MusteriSinifi müşteriveişlemsüresi = theQueuekopya.remove();
                müşteriişlemsüresi1 = müşteriişlemsüresi1 + müşteriveişlemsüresi.UrunSayisi;
                tekkasaiçintoplamişlemsüresi1 = tekkasaiçintoplamişlemsüresi1 + müşteriişlemsüresi1;
                Console.WriteLine("Müşteri Adı:\t" + müşteriveişlemsüresi.MusteriAdi + "\t İşlem Tamamlama Süresi: " + müşteriişlemsüresi1);
                
            }
            Console.WriteLine();
            Console.WriteLine("Tek Kasa için Ortalama İşlem Tamamlama Süresi(Kuyruk) : " + tekkasaiçintoplamişlemsüresi1 / MüşteriAdı.Length);
            Console.WriteLine();
            
            Console.WriteLine("Öncelikli Kuyruk Kullanarak Hesaplanan İşlem Süreleri:");
            double müşteriişlemsüresi2 = 0;
            double tekkasaiçintoplamişlemsüresi2 = 0;
            while (!onceliklikuyrukkopya.bosMu()) 
            {
                MusteriSinifi müşteriveişlemsüresi2 = onceliklikuyrukkopya.kucuktenbüyüğesil();
                müşteriişlemsüresi2 = müşteriişlemsüresi2 + müşteriveişlemsüresi2.UrunSayisi;
                tekkasaiçintoplamişlemsüresi2 = tekkasaiçintoplamişlemsüresi2 + müşteriişlemsüresi2;
                Console.WriteLine("Müşteri Adı:\t" + müşteriveişlemsüresi2.MusteriAdi + "\t İşlem Tamamlama Süresi: " + müşteriişlemsüresi2);
            }
            Console.WriteLine();
            Console.WriteLine("Tek Kasa İçin Ortalama İşlem Tamamlama Süresi(PQ) : "+ tekkasaiçintoplamişlemsüresi2/MüşteriAdı.Length);
            Console.ReadKey();

        }
    }
}
