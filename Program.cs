using System;
using Humanizer;
using System.Threading;
using System.Globalization;

namespace HumanizerPost
{
	class MainClass
	{
		private static CultureInfo CurrentCulture = new CultureInfo("es-ES");
		
		public static void Main (string[] args)
		{
			Thread.CurrentThread.CurrentUICulture = CurrentCulture;
			
			var contest = new Event 
			{
				Number = 8,
				Name = "Concurso Anual de Programación",
				Description = "El Capitulo Estudiantil ACM de la Escuela Superior de Cómputo del Instituto Politécnico Nacional los invita a participar en esta edición del Concurso Anual de Programación, en el marco de las actividades de la ExpoESCOM.",
				Start = new DateTime(2016,2, 29, 10,0,0),
				End = new DateTime(2016,2,29,17,30,0)
			};

			Console.WriteLine ("No humanizado:\n");
			PrintEventInfo (contest);
			Console.WriteLine ("Humanizado:\n");
			PrintHumanizedEventInfo (contest);
		}

		public static void PrintEventInfo(Event evt){
			Console.WriteLine ("Evento número " + evt.Number);
			Console.WriteLine (evt.Name);
			Console.WriteLine (evt.Description);
			Console.WriteLine ("Número de asistentes: " + evt.Attendants);
			Console.WriteLine ("Fecha: " + evt.Start.ToLongDateString());
			Console.WriteLine ("Duración: de " + evt.Start.ToLongTimeString () + " a " + evt.End.ToLongTimeString ());
		}

		public static void PrintHumanizedEventInfo(Event evt){
			Console.WriteLine (evt.Number.ToOrdinalWords(GrammaticalGender.Masculine).Titleize() + " evento");
			Console.WriteLine (evt.Name);
			Console.WriteLine (evt.Description.Truncate(60,"..."));
			Console.WriteLine ("asistente".ToQuantity(evt.Attendants, ShowQuantityAs.Words));
			Console.WriteLine (evt.Start.Humanize(true, DateTime.Now,new CultureInfo("es")).Humanize(LetterCasing.Sentence));
			Console.WriteLine ((evt.End - evt.Start).Humanize(3));
		}
	}
}
