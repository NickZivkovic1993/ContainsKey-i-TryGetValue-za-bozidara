using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace ContainsKey_i_TryGetValue
{

    /// <summary>
    /// Odmah cu da se ogradim ovde da nisam cesto samo par puta radio sa ovim metodama
    /// Al posto ne smem da koristim internet koristim samo windowsovu dokumentaciju u sklopu
    /// Visual studia tako da mozda ne bude ispravno , radije bih da sam iskren nego da 
    /// da muljam nesto (iskreno algoritmi i strukture su mi bile davno al svaki put kad mi treba nesto ja ga nadjem i implementiram)
    /// secam se da sam radio nesto sa hashmapama s ovim al je bilo pre par meseci jer sam se fokusirao na projekte
    /// Al da imam izlaz internetu uradio bih ovo za manje vremena nego sto bi mi trebalo da iskucam ovo
    /// 
    /// sad na odgovor : 
    /// Obe metode pronalaze da li se neka/neke vrednosti nalaze u odredjenom Dictionary-u
    /// TryGetValue iliti imeDictionary.TryGetValue(kljuc,vrednost)  prolazi samo jednom i vraca bool varijantu
    /// Naime da li se vrednost sa tim kljucem nalazi u tom imeDictionary (true) ili se ne nalazi (false)
    /// S tim sto TryGetValue value VRACA VREDNOST! dok to COntainsKey ne radi za koju je vezan kljuc
    /// 
    /// ContainsKey je metoda koja proverava da li se neki kljuc zapravo nalazi u Dictionary - u , bar mislim da nema nekad poente
    /// da se se pokusava dobijati vrednost za nesto ne postoji (nemoj me drzati za rec , ovo je cisto moje razmisljanje naglas 
    /// iliti u komentaru^^ mada mogu da zamislim jos par stvari gde bi bilo korisno(testiranje za dodaju novih ljuceve itd)
    /// al vec previse smaram ovde
    /// Isto vraca boolean vrednost s tim sto samo potvrdjuje dal taj kljuc postoji(true ) ili ne (false)
    /// 
    /// 
    /// kompleksnosti algoritma koje vidim ovde bi trebale da budu da za TryGetValue da tezi O(1)
    /// a za ContainsKey ce biti od O(1) u najboljem slucaju do O(n) u najgorem gde ce u hashmapi biti mnogo "sudara"
    /// probao sam da merim al na ovako maloj kolicini podataka nisu reprezantitivni podaci , zato kad sam malo razmislio sam dopisao ovo
    /// 
    /// </summary>
    /// 
    ///
    internal class Program
    {
        public static Dictionary<string, string> CreateDictionary()
        {
            Dictionary<string, string> testDictionary = new Dictionary<string, string>()
            {
                ["txt"] = "notepad.txt",
                ["cs"] = "program.cs",
                ["exe"] = "definitivelyNotAVirus.exe",
                ["dll"] = "noUseForLibrarieshere.lib"

            };

            return testDictionary;
        }

        private static void TryGetValueTest(Dictionary<string, string> testDictionary , string key)
        {
            //DateTime start = DateTime.Now;
            //setio sam se da postoji ovo sto je preciznije^^
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            {
                //string key = "exe";
                string vrednost = "";
                if (testDictionary.TryGetValue(key, out vrednost))
                {
                    Console.WriteLine($"Za kljuc = {key} vrednost je {vrednost}");
                }
                else
                {
                    Console.WriteLine($"Za kljuc = {key} vrednost nije nadjena");
                }
            }
            //TimeSpan vreme = DateTime.Now - start;
            sw.Stop();
            Console.WriteLine($"Vreme Izvrsavanje = {sw.Elapsed.Nanoseconds} nanosekundi");
        }

        private static void AddIfNotContained(string key , string value , Dictionary<string, string> testDictionary)
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            //ja volim da ipak potrosim sekundu da pusem == false jer nekad se ! ne vidi pogotovu kad je prvo slovo i ili l pa bude zabune
            // a ovde da dodam neku vrednost ako ne sadrzi "png" kluc
            if (testDictionary.ContainsKey(key) == false)
            {
                testDictionary.Add(key, value);
                Console.WriteLine($"kljuc {key} i vrednost {value} dodata u testDictionary");
            }
            sw.Stop();
            Console.WriteLine($"Vreme Izvrsavanje = {sw.Elapsed.Nanoseconds} nanosekundi");
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> testDictionary = CreateDictionary();

            TryGetValueTest(testDictionary, "exe");

            AddIfNotContained("png", "Slika.png", testDictionary);

        }
    }
}