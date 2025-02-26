using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_07.App
{
	internal class Program
	{
		static void Thamchieu(ref int x)
		{
			x = 100;
			
		}
		static void Main(string[] args)
		{
			//int a = 4;

			//Console.WriteLine("ket qua{0}",a);
			//Thamchieu(ref  a);
			//Console.WriteLine("ket qua{0}", a);



			DateTime ngaysinhnhat = new DateTime(2004, 04, 04);
			DateTime ngayhientai = DateTime.Now;
			TimeSpan tuoi = ngayhientai.Subtract(ngaysinhnhat);
			Console.WriteLine("so ngay ton tai {0}",tuoi);



			var ngaytrongthang = DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month);
			Console.WriteLine("ngay cua thang nay: {0}",ngaytrongthang);

			String Value = "My name";
			Value = Value + " Thang";
			Console.WriteLine(Value);



		}
	}
}
