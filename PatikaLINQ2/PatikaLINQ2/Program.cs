using PatikaLINQ2;
public class Program
{
    public static void Main()
    {

        // artist listesine nesneleri ekleme 
        var artist = new List<Artist> {

        new Artist { Name = "Ajda Pekkan", MusicGenre = "Pop", ReleasedYear = 1968, SalesAmount = 20000000 },
        new Artist { Name = "Sezen Aksu", MusicGenre = "Türk Halk Müziği/Pop", ReleasedYear = 1971, SalesAmount = 10000000 },
        new Artist { Name = "Funda Arar", MusicGenre = "Pop", ReleasedYear = 1999, SalesAmount = 3000000 },
        new Artist { Name = "Sertab Erener", MusicGenre = "Pop", ReleasedYear = 1994, SalesAmount = 5000000 },
        new Artist { Name = "Sıla", MusicGenre = "Pop", ReleasedYear = 2009, SalesAmount = 3000000 },
        new Artist { Name = "Tarkan", MusicGenre = "Pop", ReleasedYear = 1992, SalesAmount = 40000000 },
        new Artist { Name = "Hande Yener", MusicGenre = "Pop", ReleasedYear = 1999, SalesAmount = 7000000 },
        new Artist { Name = "Hadise", MusicGenre = "Pop", ReleasedYear = 2005, SalesAmount = 5000000 },
        new Artist { Name = "Gülben Ergen", MusicGenre = "Pop/Türk Halk Müziği", ReleasedYear = 1997, SalesAmount = 10000000 },
        new Artist { Name = "Neşet Ertaş", MusicGenre = "Türk Halk Müziği/Türk Sanat Müziği", ReleasedYear = 1960, SalesAmount = 2000000 },
    };


        //İsmi S harfi ile başlayan sanatçılar
        var artistName = artist.Where(x => x.Name.StartsWith("S", StringComparison.OrdinalIgnoreCase));

        foreach (var item in artistName)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("--------------------------------");

        //Albüm satışları 10 milyon üzerinde olan şarkıcılar
        var albumSales = artist.Where(x => x.SalesAmount > 10000000);

        foreach (var item in albumSales)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("--------------------------------");


        //2000 yılı öncesi çıkmış pop müzik sanatçıları
        var before2000 = artist.Where(x => x.ReleasedYear < 2000 && x.MusicGenre.Contains("Pop"))
                               .GroupBy(x => x.ReleasedYear);

        foreach (var item in before2000)
        {
            Console.WriteLine(item.Key);

            foreach (var names in item.OrderBy(x=>x.Name))
            {
                Console.WriteLine(names.Name);
            }
        }

        Console.WriteLine("--------------------------------");

        //En çok satış yapan sanatçı
        var bestSale = artist.OrderByDescending(x => x.SalesAmount).First();

        Console.WriteLine($"Albüm satışı en yüksek olan sanatçı: {bestSale.Name}");


        Console.WriteLine("--------------------------------");

        //En yeni ve en eski çıkış yapan sanatçılar
        var newArtist = artist.OrderByDescending(x=>x.ReleasedYear).First();
        var oldArtist = artist.OrderBy(x => x.ReleasedYear).First();

        Console.WriteLine($"En yeni çıkış yapan sanatçı : {newArtist.Name} ve en eski çıkış yapan sanatçı : {oldArtist.Name}");

        }
}


        

    
