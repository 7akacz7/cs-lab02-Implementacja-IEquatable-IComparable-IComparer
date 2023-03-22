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
    #region implementacja IEquatable<Pracownik>
    public bool Equals(Pracownik other)
    {
        if (other is null) return false;
        if (Object.ReferenceEquals(this, other)) //other i this są referencjami do tego samego obiektu
            return true;

        return (Nazwisko == other.Nazwisko &&
                DataZatrudnienia == other.DataZatrudnienia &&
                Wynagrodzenie == other.Wynagrodzenie);
    }
    public override bool Equals(object obj)
    {
        if (obj is Pracownik)
            return Equals((Pracownik)obj);
        else
            return false;
    }
    public override int GetHashCode() => (Nazwisko, DataZatrudnienia, Wynagrodzenie).GetHashCode();
    public static bool Equals(Pracownik p1, Pracownik p2)
    {
        if ((p1 is null) && (p2 is null)) return true; // w C#: null == null
        if ((p1 is null)) return false;

        //p1 nie jest `null`, nie będzie NullReferenceException
        return p1.Equals(p2);
    }
    public static bool operator ==(Pracownik p1, Pracownik p2) => Equals(p1, p2);
    public static bool operator !=(Pracownik p1, Pracownik p2) => !(p1 == p2);

    #endregion implementacja IEquatable<Pracownik>
}
