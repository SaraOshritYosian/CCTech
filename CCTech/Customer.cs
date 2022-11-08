using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace CCTech
{

	class Customer
	{
		public static double mekademOmes;
		//public static int numOfCustomers = 0;
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
		public bool isInCharge;
		private int wantedHours;
		public static int nuberOfCustomers = 0;

		//public Customer()
  //      {
		//	nuberOfCustomers++;
		//	this.name = "";
		//	this.cellphoneNumber = "";
		//	this.currentPercentage = 0;
		//	this.exitTime = new DateTime();
		//	mekademOmes = 0;
		//}
		public Customer(string name, string phone, int currentBattery, DateTime leavingTime)
		{
			nuberOfCustomers++;
			this.name = name;
			this.cellphoneNumber = phone;
			this.currentPercentage = currentBattery;
			this.exitTime = leavingTime;			
			mekademOmes = StandsCharging.numberOfStands / nuberOfCustomers;
			isInCharge = false;
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

		public DateTime getExitTime()
        {
			return exitTime;
        }
		public void setExitTime(DateTime newExitTime)
        {
			exitTime = newExitTime;
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

		public double Priority { get { return priority; } }

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
		public int RaundedHefreshHours()
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
			return wantedHours;
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
            //MessageBox.Show("Come and pick up your car,fees will be applied for arriving late");
            //// או לפתוח חלון
            //MessageBox.Show("when you arrived please enter 1");
            //int answere = Convert.ToInt32(Console.ReadLine());
			//while (answere != 1)
			//{
			//	MessageBox.Show("when you arrived please enter 1,fees will be applied for arriving late");
			//	answere = Convert.ToInt32(Console.ReadLine());
			//}
			
			//הגיע
			nuberOfCustomers--;
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
		public void startCharge()
		{
			this.entryTime = DateTime.Now;
		}
		public double possibblePrecents()//כמה אחוזים ניתן לו
		{
			 mekademOmes = StandsCharging.numberOfStands / nuberOfCustomers;
			double p = mekademOmes * 100; //כמה אחוזים אפשר לתת לו להטעין
			if (p + currentPercentage < 20)
			{
				p = 20 - currentPercentage;//מינימום סוללה ברכב
			}
			if (p + currentPercentage > 100)
			{
				p = 100 - currentPercentage;
			}
			return p;
		}
		public void checkIfFinishCharge()//חלק1
		{
			int minutesOfCharging = HefreshMinuts();
			currentPercentage += (int)(HefreshMinuts() * percentsPerHour);

            if (currentPercentage >= possibblePrecents() - 3)
            {
				feeTimeStart = DateTime.Now;
				fineAmount = sendMassage(this);
				
				
				currentPercentage += 3;//מוסיף את האחוזים הנותרים להטענה רצויה
				if (fineAmount >= 15 && fineAmount < 100)
				{
					MessageBox.Show("You have a fee in amount of" + fineAmount);
				}
				else
				{
					MessageBox.Show("Your car will be taken");
				}
				//MessageBox.Show("Your car is charged succesfully!");

        }
        //לא סיימנו להטעין
    }

		public string ToString()
        {
			return name;
        }
		public void charging(int wantedHours)//מטעינה לפי מספר השעות הרצויות
		{
			int wantedPrecent = wantedHours * 15;//כמה אחוזים השעות טעינה האלו שוות
			while (currentPercentage < wantedPrecent - 3)//כי אני שולחת הודעה בשלושה האחרונים שיבוא לקחת
			{
				currentPercentage += (int)(HefreshMinuts() * percentsPerHour);

			}
			//הטענו פחות 3 אחוזים
			//fineAmount = sendMassage(this);
			//	feeTimeStart = DateTime.Now;
			//
			//	currentPercentage += 3;//מוסיף את האחוזים הנותרים להטענה רצויה
			//	if (fineAmount >= 15 && fineAmount < 100)
			//	{
			//		Console.WriteLine("You have a fee in amount of" + fineAmount);
			//	}
			//	else
			//	{
			//		Console.WriteLine("Your car will be taken");
			//	}
			//	Console.WriteLine("Your car is charged succesfully!");
			//}

		}

	}
}