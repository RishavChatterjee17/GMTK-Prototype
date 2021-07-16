using UnityEngine;

public class DataBase
{
    #region Properties

    /// <summary>
    /// The emails in the database
    /// </summary>
    public Emails Emails
    {
        set;
        get;
    }

    #endregion
    
    #region Singleton

    /// <summary>
    /// Data base instance for singleton
    /// </summary>
    private static DataBase _instance;

    /// <summary>
    /// Data base instance
    /// </summary>
    public static DataBase Instance
    {
        get
        {
            if (_instance == null)
                _instance = new DataBase();
            return _instance;
        }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    private DataBase()
    {

    }

    #endregion

    #region Methods

    /// <summary>
    /// Load data to dataset
    /// </summary>
    public void LoadData(TextAsset stringsFile)
    {
        //Emails = JsonUtility.FromJson<Emails>(stringsFile.text);
        Emails = JsonUtility.FromJson<Emails>(stringsFile.text);
        Debug.Log(Emails == null);
        Debug.Log(Emails.emails == null);
    }

    #endregion
}
