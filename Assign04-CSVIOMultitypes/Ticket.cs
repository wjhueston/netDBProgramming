using System;

public class Ticket
{
	public int idNumber { get; set; }
	public string summary { get; set; }
	public string status { get; set; }
	public string priority { get; set; }
	public string submitter { get; set; }
	public string assigned { get; set; }
	public string watchers { get; set; }

	

	public Ticket(int id, string summ, string stat, string prio, string sub, string assign, string watch)
	{
		idNumber = id;
		summary = summ;
		status = stat;
		priority = prio;
		submitter = sub;
		assigned = assign;
		watchers = watch;
		
	}
	
}
