using System;

public class CovidConfig
{
    public string SatuanSuhu { get; set; }
    public int BatasHariDeman { get; set; }
    public string PesanDitolak { get; set; }
    public string PesanDiterima { get; set; }

    public CovidConfig()
    {
        SatuanSuhu = "celcius";
        BatasHariDeman = 14;
        PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
    }

    public void UbahSatuan()
    {
        SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
    }

    public double KonversiSuhu(double suhu)
    {
        if (SatuanSuhu == "celcius")
        {
            return suhu * 9 / 5 + 32;
        }
        else 
        {
            return (suhu - 32) * 5 / 9;
        }
        
    }
}

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        config.UbahSatuan(); 

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());
        suhu = config.KonversiSuhu(suhu); 

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari_deman = Convert.ToInt32(Console.ReadLine());

        if ((config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5) ||
            (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5))
        {
            if (hari_deman < config.BatasHariDeman)
            {
                Console.WriteLine(config.PesanDiterima);
            }
            else
            {
                Console.WriteLine(config.PesanDitolak);
            }
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }
    }
}
