using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomatenAufgabe
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Bestellung _bestellung;
		List<Ticket> _tickets;

		public MainWindow()
		{
			InitializeComponent();
			_bestellung = new Bestellung();
			_tickets = new List<Ticket>();
		}

		private void Button_Fahrkarte_Click(object sender, RoutedEventArgs e)
		{
			if (_bestellung.FahrkarteKaufen())
			{
				Label_Karten.Content = _bestellung.AnzahlKarten.ToString();
				if(_bestellung.Wechselgeld >= 0)
				{
					Lbl_Wechselgeld_Info.Content = "Ihr Wechselgeld beträgt in €: ";
					Lbl_Wechselgeld.Content = _bestellung.Wechselgeld;
					_bestellung.AnzahlGeld = 0;
					Label_Guthaben.Content = "0";
					Label_Info.Content = $"Sie haben {_tickets.Count} Tickets gekauft.";
					_tickets.Clear();
					_bestellung.Gesamtkosten = 0;
					Lbl_GesamtKosten.Content = _bestellung.Gesamtkosten.ToString();
				}
				
			} else
			{
				Label_Info.Content = _bestellung.Fehler();
				Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
			}
				
		}

		private void Btn_1EU_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 1;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();

		}

		private void Btn_50ct_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 0.50M;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();

		}

		private void Btn_2EU_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 2;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_20ct_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 0.20M;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_10ct_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 0.10M;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_5EU_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 5;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_10EU_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 10;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_20EU_Click(object sender, RoutedEventArgs e)
		{
			_bestellung.AnzahlGeld += 20;
			Label_Guthaben.Content = _bestellung.AnzahlGeld.ToString();
		}

		private void Btn_AB_Ticket_Click(object sender, RoutedEventArgs e)
		{
			Ticket ticket = new Ticket(2.90M);
			_tickets.Add(ticket);
			_bestellung.Gesamtkosten += 2.90M;
			Lbl_GesamtKosten.Content = _bestellung.Gesamtkosten.ToString();
			Label_Karten.Content = _tickets.Count.ToString();

		}

		private void Btn_BC_Ticket_Click(object sender, RoutedEventArgs e)
		{
			Ticket ticket = new Ticket(3.30M);
			_tickets.Add(ticket);
			_bestellung.Gesamtkosten += 3.30M;
			Lbl_GesamtKosten.Content = _bestellung.Gesamtkosten.ToString();
			Label_Karten.Content = _tickets.Count.ToString();

		}

		private void Btn_ABC_Ticket_Click(object sender, RoutedEventArgs e)
		{
			Ticket ticket = new Ticket(3.60M);
			_tickets.Add(ticket);
			_bestellung.Gesamtkosten += 3.60M;
			Lbl_GesamtKosten.Content = _bestellung.Gesamtkosten.ToString();
			Label_Karten.Content = _tickets.Count.ToString();
		}
	}

	public class Ticket
	{
		public decimal Ticket_Preis { get; set; } = 0.0M;

		public Ticket(decimal preis)
		{
			Ticket_Preis = preis;
		}

	}

	public class Bestellung
	{
		public int AnzahlKarten { get; set; } = 0;

		public decimal AnzahlGeld { get; set; } = 0.0M;

		public decimal Gesamtkosten { get; set; } = 0.0M;

		public decimal Wechselgeld { get; set; } = 0.0M;

		public bool FahrkarteKaufen()
		{
			if (AnzahlGeld < Gesamtkosten)
				return false;
			AnzahlGeld -= Gesamtkosten;
			Wechselgeld += AnzahlGeld;
			return true;
		}

		public string Fehler()
		{
			return "Nicht genug Geld vorhanden!";
		}
	}
}

