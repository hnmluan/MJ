using System;

public class TxtCoutResetShop : BaseText
{
    //protected virtual void FixedUpdate() => this.UpdateText();

    /*    protected virtual void UpdateText()
        {
            int coutDown = UIShop.Instance.IntervalRestItem - UIShop.Instance.GetDeltaTimeReset();

            text.text = SecondToTime(coutDown);
        }*/

    private string SecondToTime(int seconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);

        string t = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

        return t;
    }

}
