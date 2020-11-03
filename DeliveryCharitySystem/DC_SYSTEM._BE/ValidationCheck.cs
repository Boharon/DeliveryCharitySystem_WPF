using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM._BE
{
	
        public class ValidationCheck
        {
            // Checks if all chars are in hebrew 
            public  bool IsHebrewLetters(string word)
            {
                string letters = " אבגדהוזחטיכלמנסעפצקרשתךםןףץ";
                for (int i = 0; i < word.Length; i++)
                {
                    if (letters.IndexOf(word[i]) == -1)
                        return false;
                }
                return true;

            }

            // Checks if all chars are digits 
            public  bool IsNumbers(string stNum)
            {
                for (int i = 0; i < stNum.Length; i++)
                {
                    if (stNum[i] < '0' || stNum[i] > '9')
                        return false;
                }
                return true;
            }
            // Checks if phone number is valid 
            public  bool IsPhoneNumber(string phoneNumber)
            {
                if (!(IsNumbers(phoneNumber)))
                    return false;
                if (phoneNumber.Length != 9 && phoneNumber.Length != 10)
                    return false;
                return true;
            }

            // Checks if id is valid 
            public  bool IsIdentify(string identify)
            {
                if (IsNumbers(identify) && (identify.Length == 9))
                    return true;
                return false;
            }
            // Checks if all chars are in hebrew or digits
            public  bool IsHebrewLettersAndNumbers(string address)
            {
                string lettersAndNumbers = " אבגדהוזחטיכלמנסעפצקרשת0123456789םףץןך/";
                for (int i = 0; i < address.Length; i++)
                    if (lettersAndNumbers.IndexOf(address[i]) == -1)
                        return false;
                return true;

            }
            //  Checks if date is valid - bigger than today.
            public  bool IsDateValid(DateTime date)
            {
                if (date > DateTime.Now)
                    return false;
                return true;
            }
        public bool IsSelectedOption(bool f , bool m)
        {
            if (!f && !m)
                return false;
            return true;
        }



       
    }
}


