using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
	public class ValidateData
	{	
		public static bool CheckNull_Data(string input)
		{
			return string.IsNullOrEmpty(input)? false : true;
		}
		public static bool IsNumeric(String input)
		{
			int n;
			bool isNumeric = int.TryParse(input, out n);
			return isNumeric;
		}
		public static bool CheckValiDateTime(String input)
		{
			DateTime dateValue;
			if (!DateTime.TryParseExact(input,"dd/MM/yyyy",new CultureInfo("en-US"),DateTimeStyles.None,out dateValue))
			{
				return false;
			}

			
			return true;

		}
	}
}
