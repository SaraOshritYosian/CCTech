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
		private DateTime exitTime;//To calculate his priority
		private DateTime entryTime;//Obsolescence
		private string name;//For the message
		private string cellphoneNumber;//For the message
		private double priority;//For a priority queue
		private float fineAmount = 0;//If he's late
		private int currentPercentage;//To calculate his priority
		private int wantedHours;
		public static int nuberOfCustomers = 0;

		public Customer()
        {
			nuberOfCustomers++;
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
			priority = butteryWeightPrecents * PrecentsNormalize() + hoursWeightPrecents* HoursNormalize();

		}
	}
	
}
	
