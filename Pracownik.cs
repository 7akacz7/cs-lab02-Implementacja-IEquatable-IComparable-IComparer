﻿using System;

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
}
