using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTech
{

	class Customer
	{
		const double butteryWeightPrecents = 0.7;
		const double hoursWeightPrecents = 0.3;
		DateTime feeTimeStart;
		DateTime feeTimeEnd;
		DateTime startCharging;
		const double percentsPerHour = 0.25;//אחוז טעינה לדקת הטענה
		private DateTime exitTime;//To calculate his priority
		private DateTime entryTime;//Obsolescence
		private string name;//For the message
		private string cellphoneNumber;//For the message
		private double priority;//For a priority queue
		private float fineAmount = 0;//If he's late
		private int currentPercentage;//To calculate his priority
		private int wantedHours;
		public static int nuberOfCustomers = 0;
		
		
		public Customer(string name,string phone,int currentBattery,int wantedHours)
		{
			nuberOfCustomers++;
			this.name = name;
			this.cellphoneNumber = phone;
			this.currentPercentage = currentBattery;
			this.wantedHours = wantedHours;
		}
		public Customer(string _name, string phone, DateTime leavingTime, int percent)
        {
			feeTimeStart = DateTime.Now;
			feeTimeEnd = leavingTime;
			name = _name;
			cellphoneNumber = phone;
			currentPercentage = percent;
			wantedHours = nuberOfCustomers;
        }
		public void SetDepartureTime(DateTime newDepartureTime)
		{
			exitTime = newDepartureTime;
		}

		public DateTime GetDepartureTime()
		{
			return exitTime;
		}

		public void SetEntryTime(DateTime newEntryTime)
		{
			entryTime = newEntryTime;
		}

		public DateTime GetEntryTime()
		{
			return entryTime;
		}

		public void SetName(string newName)
		{
			name = newName;
		}

		public string GetName()
		{
			return name;
		}

		public void SetCellphoneNumber(string newCellphoneNumber)
		{
			cellphoneNumber = newCellphoneNumber;
		}

		public string GetCellphoneNumber()
		{
			return cellphoneNumber;
		}

		public void SetPriority(int newPriority)
		{
			priority = newPriority;
		}

		public double GetPriority()
		{
			return priority;
		}

		public void SetFineAmount(int newFineAmount)
		{
			fineAmount = newFineAmount;
		}

		public float GetFineAmount()
		{
			return fineAmount;
		}

		public void SetCurrentPercentage(int newCurrentPercentage)
		{
			currentPercentage = newCurrentPercentage;
		}

		public int GetCurrentPercentage()
		{
			return currentPercentage;
		}
		public int HefreshMinuts()
		{
			return exitTime.Hour * 60 + exitTime.Minute - entryTime.Hour * 60 + entryTime.Minute;

		}
		public int HefreshMinutsForFee()
		{
			return feeTimeEnd.Hour * 60 + feeTimeEnd.Minute - feeTimeStart.Hour * 60 + feeTimeStart.Minute;
		}
		public void RaundedHefreshHours()
		{
			int hefreshByMinuts = HefreshMinuts();
			int x = hefreshByMinuts / 60;
			int y = hefreshByMinuts - x * 60;
			if (y >= 30)
			{
				wantedHours = x + 1;
			}
			else
			{
				wantedHours = x;
			}
		}


		public double HoursNormalize()
		{
			return ((double)wantedHours) / 24;

		}
		public double PrecentsNormalize()
		{
			return ((double)currentPercentage) / 100;
		}
		public void CalcPriority()
		{
			priority = butteryWeightPrecents * PrecentsNormalize() + hoursWeightPrecents * HoursNormalize();

		}

		public int sendMassage(Customer c)//שולחת הודעה ומחזירה את סכום הקנס
		{

			Console.WriteLine("Come and pick up your car,fees will be applied for arriving late");// או לפתוח חלון
			Console.WriteLine("when you arrived please enter 1");
			int answere = int.Parse(Console.ReadLine());
			while (answere != 1)
			{
				Console.WriteLine("when you arrived please enter 1,fees will be applied for arriving late");
				answere = int.Parse(Console.ReadLine());
			}
			//הגיע

			feeTimeEnd = DateTime.Now;
			int sumTimeByMinuts = HefreshMinutsForFee();
			if (sumTimeByMinuts < 15)
			{
				return 0;
			}
			if (sumTimeByMinuts >= 15 && sumTimeByMinuts < 30)
			{
				return 15;
			}
			if (sumTimeByMinuts >= 30 && sumTimeByMinuts < 60)
			{
				return 50;
			}
			if (sumTimeByMinuts >= 60)
			{
				return 100;
			}
			return 0;
			//Console.WriteLine("Did you arrive?");
			//string answer = Console.ReadLine();

		}
		public void charging(int wantedHours)//מטעינה לפי מספר השעות הרצויות
		{
			int wantedPrecent = wantedHours * 15;//כמה אחוזים השעות טעינה האלו שוות
			while (currentPercentage < wantedPrecent - 3)//כי אני שולחת הודעה בשלושה האחרונים שיבוא לקחת
			{
				currentPercentage = (int)(HefreshMinuts() * percentsPerHour);

			}
			//הטענו פחות 3 אחוזים
			fineAmount = sendMassage(this);
			feeTimeStart = DateTime.Now;
			currentPercentage += 3;//מוסיף את האחוזים הנותרים להטענה רצויה
			if (fineAmount >= 15 && fineAmount < 100)
			{
				Console.WriteLine("You have a fee in amount of" + fineAmount);
			}
			else
			{
				Console.WriteLine("Your car will be taken");
			}
			Console.WriteLine("Your car is charged succesfully!");
		}

	}

}