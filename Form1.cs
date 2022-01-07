using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] calories = new int[7, 3]
           {
                {900,750,1020}, // we have 7 rows and 3 columns 
                {300,1000,2700}, // this is going sidewards
                {500,700,2100},
                {400,900,1780},
                {600,1200,1100},
                {575,1150,1900},
                {600,1020,1700}
           };  // so here we have our row automatically know it contains 3 rows and 4 columns. C# is a row based language so it fills rows (across) first.

        string[] mealTimes = { "Breakfast", "Lunch", "Dinner" }; // going down

        double[] dailyAverage = new double[7]; // the average calories eaten per day using all 7 days
        double[] mealAverage = new double[3]; // the average calories per THREE MEALS using all 3 meals per day

        private void button1_Click(object sender, EventArgs e)
        {
            dailyAverage = CalculateAverageByDay(calories);
            mealAverage = CalculateAverageByMeal(calories);

            string msg = "";
            msg += DisplayDailyAverage(dailyAverage);
            msg += DisplayAverageByMeal(mealAverage);
            msg += DisplayAverageCaloriesPerMeal(calories);
            MessageBox.Show(msg, "Calories Counter");

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        public double[] CalculateAverageByDay(int[,] calories) // this method parses a 2D array as an argument so when it is invoked in the button, it returns the 7 values per array address. calc average by the rows (7 which is days)
        {
            int sum = 0; // this will be a storage location for our average calculations.
            double[] dailyAv = new double[7];  // seven days so we need 7 rows 

            for (int row = 0; row < calories.GetLength(0); row++)
            {
                for (int col = 0; col < calories.GetLength(1); col++)
                    sum += calories[row, col];// calories location works like calories [0,1]
                dailyAv[row] = (double)sum / calories.GetLength(1); // we wanna divide the calories per day by the number of days which is our 7 (get length )
                sum = 0; // this is to make the sum 0 again before iterating for the next value of calories. until we finish the rows!
            }
            return dailyAv;

        }

        public double[] CalculateAverageByMeal(int[,] calories) // calc average by the columns which is 3
        {
            int sum = 0;
            double[] mealAv = new double[3]; // whats on top now is all the meal options instead which is 27 (all 27 meals/3)
            for (int column = 0; column < calories.GetLength(1); column++) // always remember we increment starting from 0 going upwards. so 0 = first entry in the array and hence our last element's position is n-1 so 1 lower than the maximum of our array hence "<" and not "<=".
            {
                for (int row = 0; row < calories.GetLength(0); row++) // row is always under 7 UNTIL it finishes.
                    sum += calories[row, column]; // our result here is us adding ALL of the calories (column values) togetha

                mealAv[column] = (double)sum / calories.GetLength(0); // getLength(1) is 7 ( our column)
                sum = 0;
            }

            return mealAv; // returning the reference of meal average not value.

            // notice how we have used our inner loop as our row. this is because the inner loop must be what we wanna really work on which in this case is the values of the actual calorie value of the meals. in the CalcAvg by day method we were wanting to work on the total calories per day split into how much were averaged PER 1 DAY.
        }

        

        public string DisplayMealAverage(double[] mealAverage)
        {
            string result = "";
            result += "\n\n Meal averages \n"; // leaving space and jumping lines for every value we are concatenating.

            for (int i = 0; i < mealAverage.Length; i++)
            {
                result += string.Format("{0, -20} : {1, 6} \n", mealTimes[i], mealAverage[i].ToString("N0"));
            }
            return result;
        }


        public string DisplayAverageByMeal(double[] mealAverage)
        {
            string result = "";
            result += "\n\n Meal averages \n"; // leaving space and jumping lines for every value we are concatenating.

            for (int i = 0; i < mealAverage.Length; i++)
            {
                result += string.Format("{0, -20} : {1, 6} \n", mealTimes[i], mealAverage[i].ToString("N0"));
            }
            return result;
        }

        public string DisplayDailyAverage(double[] dailyAverage)
        {
            int dayNumber = 1;
            string result = "";
            result += "\n Daily average";

            foreach (double av in  dailyAverage)
            {
                result += string.Format("\n Day {0} : {1, 6:N0} ", dayNumber, av);
                dayNumber++;
            }

            return result;

        }

        public string DisplayAverageCaloriesPerMeal (int [,] calories) // uses a 2d array for calories.
        {
            string result = "";
            double sum = 0;
            for (int row = 0; row < calories.GetLength(0); row++)
                for (int col = 0; col < calories.GetLength(1); col++)
                    sum += calories[row, col];
            result += string.Format("\n Calories average per meal: " +  "{0:N0}", sum / calories.Length);
            return result;
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    

  


