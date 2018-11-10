using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Appius.Core.Utility
{
	/// <summary>
	/// Check
	/// </summary>
	public static class Validation
	{
		public const string PATTERN_SPECIAL_DATE = @"^\d{1,2}\/\d{1,2}\/\d{4}$"; //dd/mm/yyyy
        public const string PATTERN_SPECIAL_DATE_ALTERNATIVE = @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$"; //yyyy-mm-dd
        public const string PATTERN_SPECIAL_URI = @"(?<http>((http|https):[/][/]|www.)([a-z]|[A-Z]|[0-9]|[/.]|[~])*(\.)+)";
		public const string PATTERN_SPECIAL_IP_ADDRESS = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
		public const string PATTERN_SPECIAL_EMAIL = @"^(([^<>()[\]\\.,;:\s@\""]+" + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@" + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}" + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+" + @"[a-zA-Z]{2,}))$";
        public const string PATTERN_SPECIAL_PASSWORD = @"((?=.*\d)(?=.*[a-zA-Z].*)(?=.*[0-9].*).{8,20})";
		public const string PATTERN_TEXT_CHARS = @"[^a-zA-Z]";
		public const string PATTERN_TEXT_NAME = @"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$";
		public const string PATTERN_TEXT_STRING = @"^[1-zA-Z0-1@.\s]{1,255}$";
		public const string PATTERN_TEXT_MASTERCARD = @"^([51|52|53|54|55]{2})([0-9]{14})$";
		public const string PATTERN_TEXT_VISA = @"^([4]{1})([0-9]{12,15})$";
		public const string PATTERN_TEXT_AMEX = @"(3(4[0-9]{2}|7[0-9]{2}))([0-9]{11})";
		public const string PATTERN_TEXT_SOLO = @"(^(6334)[5-9](\d{11}$|\d{13,14}$)) | (^(6767)(\d{12}$|\d{14,15}$))";
		public const string PATTERN_TEXT_SWITCH = @"(^(49030)[2-9](\d{10}$|\d{12,13}$)) |(^(49033)[5-9](\d{10}$|\d{12,13}$)) |(^(49110)[1-2](\d{10}$|\d{12,13}$)) |(^(49117)[4-9](\d{10}$|\d{12,13}$)) |(^(49118)[0-2](\d{10}$|\d{12,13}$)) |(^(4936)(\d{12}$|\d{14,15}$)) |(^(564182)(\d{11}$|\d{13,14}$)) |(^(6333)[0-4](\d{11}$|\d{13,14}$)) |(^(6759)(\d{12}$|\d{14,15}$))";
		public const string PATTERN_TEXT_MAESTRO = @"(^(5[0678])\d{11,18}$)(^(6[^05])\d{11,18}$)(^(601)[^1]\d{9,16}$)(^(6011)\d{9,11}$)(^(6011)\d{13,16}$)(^(65)\d{11,13}$)(^(65)\d{15,18}$)(^(49030)[2-9](\d{10}$\d{12,13}$))(^(49033)[5-9](\d{10}$\d{12,13}$))(^(49110)[1-2](\d{10}$\d{12,13}$))(^(49117)[4-9](\d{10}$\d{12,13}$))(^(49118)[0-2](\d{10}$\d{12,13}$))(^(4936)(\d{12}$\d{14,15}$))";
		public const string PATTERN_TEXT_UK_PHONE = @"^((\(?0\d{4}\)?\s?\d{3}\s?\d{3})|(\(?0\d{3}\)?\s?\d{3}\s?\d{4})|(\(?0\d{2}\)?\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$";
		public const string PATTERN_TEXT_IE_PHONE = @"^[0]{1}[1-9]{1}[1-9]{0-2}[1-9]{1}[0-9]{6}$";
		public const string PATTERN_TEXT_GENERIC_PHONE = @"^[0-9\s\(\)\+\-]+$";
		public const string PATTERN_TEXT_UK_MOBILE = @"^(\+44\s?7\d{3}|\(?07\d{3}\)?)\s?\d{3}\s?\d{3}$";
		public const string PATTERN_TEXT_UK_POST_CODE = @"(((^[BEGLMNS][1-9]\d?)|(^W[2-9])|(^(A[BL]|B[ABDHLNRST]|C[ABFHMORTVW]|D[ADEGHLNTY]|E[HNX]|F[KY]|G[LUY]|H[ADGPRSUX]|I[GMPV]|JE|K[ATWY]|L[ADELNSU]|M[EKL]|N[EGNPRW]|O[LX]|P[AEHLOR]|R[GHM]|S[AEGKL-PRSTWY]|T[ADFNQRSW]|UB|W[ADFNRSV]|YO|ZE)\d\d?)|(^W1[A-HJKSTUW0-9])|(((^WC[1-2])|(^EC[1-4])|(^SW1))[ABEHMNPRVWXY]))(\s*)?([0-9][ABD-HJLNP-UW-Z]{2}))|(^GIR\s?0AA)";
		public const string PATTERN_TEXT_UK_SORT_CODE = @"^[0-9]{2}[-][0-9]{2}[-][0-9]{2}$";
		public const string PATTERN_NUMBER_NUMBER = @"^[-+]?[0-9]\d*\.?[0]*$";
		public const string PATTERN_NUMBER_INTEGER = @"^[-+]?[1-9]\d*\.?[0]*$";
		public const string PATTERN_NUMBER_HEX = @"^[A-Fa-f0-9]*$";
		public const string PATTERN_NUMBER_CURRENCY = @"^[\x20ac|e|E|$|(£]-?\d+(\.\d{2})?$";
		public const string PATTERN_NUMBER_DECIMAL = @"^\d*[0-9](|.\d*[0-9]|,\d*[0-9])?$";

		/// <summary>
		/// NOTE : This method validates for UK dates in the format dd/mm/yyy
		/// </summary>
		public static bool IsDate(string strDate, bool bLimit)
		{
			bool bIsValid = true;
			Regex regPattern = new Regex(PATTERN_SPECIAL_DATE);
            Regex regPatternAlternative = new Regex(PATTERN_SPECIAL_DATE_ALTERNATIVE);

			CultureInfo culUK = new CultureInfo("en-GB");

			if (regPattern.IsMatch(strDate) || regPatternAlternative.IsMatch(strDate))
			{
				try
				{
					DateTime dt = DateTime.Parse(strDate, culUK.DateTimeFormat);

					if (bLimit)
					{
						if ((dt.Year > 2100) || (dt.Year < 1753))
							bIsValid = false;
					}
				}
				catch (Exception)
				{
					bIsValid = false;
				}
			}
			else
				bIsValid = false;

			return bIsValid;
		}

		/// <summary>
		/// NOTE : this does NOT catch all RFC 2822 possible combinations
		/// </summary>
		public static bool IsEmail(string strEmail)
		{
			Regex regPattern = new Regex(PATTERN_SPECIAL_EMAIL);
			return regPattern.IsMatch(strEmail);
		}

        /// <summary>
        /// Note: 8-20 characters, includes at least one numeric and one alpha numeric
        /// </summary>
        public static bool IsPassword(string strPassword)
        {
            Regex regPattern = new Regex(PATTERN_SPECIAL_PASSWORD);
            return regPattern.IsMatch(strPassword);
        }

        /// <summary>
        /// IsURI
        /// </summary>
        public static bool IsURI(string strURI)
        {
            Regex regPattern = new Regex(PATTERN_SPECIAL_URI);
            return regPattern.IsMatch(strURI);
        }
        
		/// <summary>
		/// IsIPAddress
		/// </summary>
		public static bool IsIPAddress(string strIPAddress)
		{
			Regex regPattern = new Regex(PATTERN_SPECIAL_IP_ADDRESS);
			return regPattern.IsMatch(strIPAddress);
		}

		/// <summary>
		/// IsAlpha
		/// </summary>
		public static bool IsAlpha(string strText)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_CHARS);
			return !regPattern.IsMatch(strText);
		}

		/// <summary>
		/// NOTE : this method will validate for text only strings also containing spaces and apostrophes
		/// </summary>
		public static bool IsName(string strText)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_NAME);
			return regPattern.IsMatch(strText);
		}

		/// <summary>
		/// IsAlphaNumeric
		/// </summary>
		public static bool IsAlphaNumeric(string strText)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_STRING);
			return regPattern.IsMatch(strText);
		}

		/// <summary>
		/// IsVisa
		/// </summary>
		public static bool IsVisa(string strCCNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_VISA);

			if (regPattern.IsMatch(strCCNumber))
				return Luhn.CheckNumber(strCCNumber);
			else
				return false;
		}

		/// <summary>
		/// IsMastercard
		/// </summary>
		public static bool IsMastercard(string strCCNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_MASTERCARD);

			if (regPattern.IsMatch(strCCNumber))
				return Luhn.CheckNumber(strCCNumber);
			else
				return false;
		}

		/// <summary>
		/// IsSolo
		/// </summary>
		public static bool IsSolo(string strCCNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_SOLO);

			if (regPattern.IsMatch(strCCNumber))
				return Luhn.CheckNumber(strCCNumber);
			else
				return false;
		}

		/// <summary>
		/// IsSwitch
		/// </summary>
		public static bool IsSwitch(string strCCNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_SWITCH);

			if (regPattern.IsMatch(strCCNumber))
				return Luhn.CheckNumber(strCCNumber);
			else
				return false;
		}

		/// <summary>
		/// IsMaestro
		/// </summary>
		public static bool IsMaestro(string strCCNumber)
		{
			if (strCCNumber.Length > 15 && strCCNumber.Length < 20)
				return true;
			else
				return false;
		}

		/// <summary>
		/// IsAmex
		/// </summary>
		public static bool IsAmex(string strCCNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_AMEX, RegexOptions.None);

			if (regPattern.IsMatch(strCCNumber))
				return true;
			else
				return false;
		}

		/// <summary>
		/// IsCreditCard
		/// </summary>
		public static bool IsCreditCard(string strCardNum)
		{
			return Luhn.CheckNumber(strCardNum);
		}

		/// <summary>
		/// IsGeneralCreditCard
		/// </summary>
		public static bool IsGeneralCreditCard(string strCardNum)
		{
			return (!IsVisa(strCardNum) && (!IsMastercard(strCardNum)) && (!IsSolo(strCardNum)) && (!IsSwitch(strCardNum)) && (!IsMaestro(strCardNum)) && (!IsAmex(strCardNum))) ? false : true;
		}

		/// <summary>
		/// IsPhoneNumber
		/// </summary>
		public static bool IsPhoneNumber(string strPhoneNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_UK_PHONE);
			return regPattern.IsMatch(strPhoneNumber);
		}

		/// <summary>
		/// only handles GBP, USD and EUR (e, E or euro symbol)
		/// </summary>
		public static bool IsGenericPhoneNumber(string strPhoneNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_GENERIC_PHONE);
			return regPattern.IsMatch(strPhoneNumber);
		}

		/// <summary>
		/// IsMobileNumber
		/// </summary>
		public static bool IsMobileNumber(string strPhoneNumber)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_UK_MOBILE);
			return regPattern.IsMatch(strPhoneNumber);
		}

		/// <summary>
		/// IsPostcode
		/// </summary>
		public static bool IsPostcode(string strPostcode)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_UK_POST_CODE);
			return regPattern.IsMatch(strPostcode.ToUpper());
		}

		/// <summary>
		/// IsSortCode
		/// </summary>
		public static bool IsSortCode(string strSortCode)
		{
			Regex regPattern = new Regex(PATTERN_TEXT_UK_SORT_CODE);
			return regPattern.IsMatch(strSortCode);
		}

		/// <summary>
		/// IsInteger
		/// </summary>
		public static bool IsInteger(string strInteger)
		{
			Regex regPattern = new Regex(PATTERN_NUMBER_INTEGER);
			return regPattern.IsMatch(strInteger);
		}

		/// <summary>
		/// IsNumber
		/// </summary>
		public static bool IsNumber(string strNumber)
		{
			Regex regPattern = new Regex(PATTERN_NUMBER_NUMBER);
			return regPattern.IsMatch(strNumber);
		}

		/// <summary>
		/// IsHex
		/// </summary>
		public static bool IsHex(string strHex)
		{
			Regex regPattern = new Regex(PATTERN_NUMBER_HEX);
			return regPattern.IsMatch(strHex);
		}

		/// <summary>
		/// IsCurrency
		/// </summary>
		public static bool IsCurrency(string strCurrency)
		{
			Regex regPattern = new Regex(PATTERN_NUMBER_CURRENCY);
			return regPattern.IsMatch(strCurrency);
		}

		/// <summary>
		/// IsDecimal
		/// </summary>
		public static bool IsDecimal(string strDecimal)
		{
			Regex regPattern = new Regex(PATTERN_NUMBER_DECIMAL);
			return regPattern.IsMatch(strDecimal);
		}

        /// <summary>
        /// IsMatch
        /// </summary>
        public static bool IsMatch(string strToMatch, string strRegex)
        {
            Regex regPattern = new Regex(strRegex);
            return regPattern.IsMatch(strToMatch);
        }
	}

	/// <summary>
	/// Manipulate
	/// </summary>
	public static class Manipulate
	{
		private const string PATTERN_HTML = @"<(.|\n)*?>";
		private const string PATTERN_NON_ALPHA = @"[^a-z0-9]";
		private const string PATTERN_SINGLE_WHITE_SPACE = "^[ \t]+|[ \t]+$";

		/// <summary>
		/// StripHtml
		/// </summary>
		public static string StripHtml(string strText)
		{
			return Regex.Replace(strText, PATTERN_HTML, string.Empty);
		}

		/// <summary>
		/// StripNonAlpha
		/// </summary>
		public static string StripNonAlpha(string strText)
		{
			return Regex.Replace(strText, PATTERN_NON_ALPHA, "", RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// StripSingleWhitespace
		/// </summary>
		public static string StripSingleWhitespace(string strText)
		{
			return Regex.Replace(strText, PATTERN_SINGLE_WHITE_SPACE, "", RegexOptions.IgnoreCase);
		}

		/// <summary>
		/// NOTE : this does NOT use regex but is here for completeness
		/// </summary>
		public static string StripAllWhitespace(string strText)
		{
			return strText.Replace(" ", "");
		}
	}

	/// <summary>
	/// Luhn
	/// </summary>
	public static class Luhn
	{
		/// <summary>
		/// CheckCardType
		/// </summary>
		public static string CheckCardType(string strNumber)
		{
			string strType = "";

			switch (strNumber.Substring(0, 1))
			{
				case "3":
					strType = "AMEX/Diners Club/JCB";
					break;

				case "4":
					strType = "VISA";
					break;

				case "5":
					strType = "MasterCard";
					break;

				case "6":
					strType = "Discover";
					break;

				default:
					strType = "Unknown";
					break;
			}

			return strType;
		}

		/// <summary>
		/// CheckNumber
		/// </summary>
		public static bool CheckNumber(string strNumber)
		{
			byte[] yNumber = new byte[16];
			int nLen = 0;

			for (int idx = 0; idx < strNumber.Length; idx++)
			{
				if (char.IsDigit(strNumber, idx))
				{
					if (nLen == 16)
						return false;
					yNumber[nLen++] = byte.Parse(strNumber[idx].ToString());
				}
			}

			int nSum = 0;

			for (int i = nLen - 1; i >= 0; i--)
			{
				if (i % 2 == nLen % 2)
				{
					int nOperand = yNumber[i] * 2;
					nSum += (nOperand / 10) + (nOperand % 10);
				}
				else
					nSum += yNumber[i];
			}

			return (bool)(nSum % 10 == 0);
		}
	}
}