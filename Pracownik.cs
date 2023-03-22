using System;

public class Pracownik
{
	public string Nazwisko { get; set; }
	Nazwisko.Trim();
	public DateTime DataZatrudnienia { get; set; }
	if(DataZatrudnienia > DateTime.Today()) throw new ArgumentException();
    public decimal Wynagrodzenie
    {
        get => _wyn;
        set => _wyn = (value < 0) ? 0 : value;
    }
    public override string ToString()
        => $"({Nazwisko}, {DataZatrudnienia:d MMM yyyy} ({CzasZatrudnienia}), {Wynagrodzenie} PLN)";
    public int CzasZatrudnienia => (DateTime.Now - DataZatrudnienia).Days / 30;
    public Pracownik(string nazwisko, DateTime dataPrzyjecia, decimal wynagrodzenie)
    {
        Nazwisko = nazwisko;
        DataZatrudnienia = dataPrzyjecia;
        Wynagrodzenie = wynagrodzenie;
    }
    public Pracownik(string nazwisko, DateTime dataPrzyjecia, decimal wynagrodzenie)
    {
        nazwisko = "Anonim";
        dataPrzyjecia = DateTime.Today();
        wynagrodzenie = 0;
    }

}
