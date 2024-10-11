namespace SD.pesel;

public class PersonId
{
    private readonly string _id;

    public PersonId(string Id)
    {
        _id = Id;
    }
    /// <summary>
    /// Get full year from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYear()
    {
        int year = int.Parse(_id.Substring(0, 2));
        int month = int.Parse(_id.Substring(2, 2));
        if (month >= 1 && month <= 12)
        {
            year += 1900;
        }
        else if (month >= 21 && month <= 32)
        {
            year += 2000;
        }
        return year;
    }

    /// <summary>
    /// Get month from PESEL
    /// </summary>
    public int GetMonth()
    {
       int month20 = 0;
        int month = int.Parse(_id.Substring(2, 2));
        if (month >= 21)
        {
            month20 = month - 20;
            string month21 = month20.ToString();
            string month22 = '0' + month21;
            int month23 = Convert.ToInt32(month22);
            return month23;
        }
        else {
            return int.Parse(month.ToString("D2"));
        }
    }

    /// <summary>
    /// Get day from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetDay()
    {
        int day = int.Parse(_id.Substring(4, 2));
        return day;
    }

    /// <summary>
    /// Get year of birth from PESEL
    /// </summary>
    /// <returns></returns>
    public int GetYearOfBirth()
    {
        int year = int.Parse(_id.Substring(0, 2));
        int month = int.Parse(_id.Substring(2, 2));
        if (month >= 1 && month <= 12)
        {
            year += 1900;
        }
        else if (month >= 21 && month <= 32)
        {
            year += 2000;
        }
        int masz = 2024 - year;
        return masz;
    }

    /// <summary>
    /// Get gender from PESEL
    /// </summary>
    /// <returns>m</returns>
    /// <returns>f</returns>
    public string GetGender()
    {
        int genderDigit = int.Parse(_id.Substring(9, 1));
        return genderDigit % 2 == 0 ? "f" : "m";
    }

    /// <summary>
    /// check if PESEL is valid
    /// </summary>
    /// <returns></returns>
    public bool IsValid()
    {
       
        if (_id.Length != 11)
        {
            return false;
        }

       
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        int sum = 0;

        
        for (int i = 0; i < 10; i++)
        {
            sum += weights[i] * int.Parse(_id[i].ToString());
        }

       
        int control = (10 - (sum % 10)) % 10;

        
        return control == int.Parse(_id[10].ToString());
    }
}