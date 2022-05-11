using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCTech
{
    class Customer
    {
		private DateTime exitTime;//To calculate his priority
		private DateTime entryTime;//Obsolescence
		private string name;//For the message
		private int cellphoneNumber;//For the message
		private int priority;//For a priority queue
		private float fineAmount = 0;//If he's late
		private float currentPercentage;//To calculate his priority
		public void setDepartureTime(DateTime newDepartureTime)
		{
			exitTime = newDepartureTime;
		}

		public DateTime getDepartureTime()
		{
			return exitTime;
		}

		public void setEntryTime(DateTime newEntryTime)
		{
			entryTime = newEntryTime;
		}

		public DateTime getEntryTime()
		{
			return entryTime;
		}

		public void setName(string newName)
		{
			name = newName;
		}

		public string getName()
		{
			return name;
		}

		public void setCellphoneNumber(int newCellphoneNumber)
		{
			cellphoneNumber = newCellphoneNumber;
		}

		public int getCellphoneNumber()
		{
			return cellphoneNumber;
		}

		public void setPriority(int newPriority)
		{
			priority = newPriority;
		}

		public int getPriority()
		{
			return priority;
		}

		public void setFineAmount(int newFineAmount)
		{
			fineAmount = newFineAmount;
		}

		public float getFineAmount()
		{
			return fineAmount;
		}

		public void setCurrentPercentage(float newCurrentPercentage)
		{
			currentPercentage = newCurrentPercentage;
		}

		public float getCurrentPercentage()
		{
			return currentPercentage;
		}
	}
}
