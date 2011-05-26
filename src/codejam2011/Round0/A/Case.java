package codejam2011.round0.a;
import java.util.*;

public class Case
{
	Stack<String> tasks = new Stack<String>();
	Stack<Integer> b = new Stack<Integer>();
	Stack<Integer> o = new Stack<Integer>();
	int steps = 0;
	int bLoc = 1;
	int oLoc = 1;
	
	public Case(String input)
	{
		Scanner s = new Scanner(input);
		if (s.hasNext())
		{
			s.next();
		}
		
		while (s.hasNext())
		{
			String bot = s.next();
			String button = s.next();
			
			tasks.add(bot + button);
			if (bot.equals("B")) { b.add(new Integer(button)); }
			if (bot.equals("O")) { o.add(new Integer(button)); }
		}
		
		Collections.reverse(tasks);
		Collections.reverse(b);
		Collections.reverse(o);
		
		while (tasks.size() > 0)
		{
			step();
		}
	}
	
	private void step()
	{
		boolean taskPerformed = false;
		
		//ORANGE
		if (o.size() > 0)
		{
			if (oLoc == o.peek())
			{
				if (tasks.peek().startsWith("O"))
				{
					o.pop(); //Press it!
					taskPerformed = true; //tasks.pop();
				}
				else
				{
					//Do Nothing. Waiting on blue.
				}
			}
			else
			{
				//Move one step closer to next spot
				if (oLoc < o.peek()) { oLoc++; }
				if (oLoc > o.peek()) { oLoc--; }
			}
		}
		
		//BLUE
		if (b.size() > 0)
			{
			if (bLoc == b.peek())
			{
				if (tasks.peek().startsWith("B"))
				{
					b.pop(); //Press it!
					taskPerformed = true; //tasks.pop(); 
				}
				else
				{
					//Do Nothing. Waiting on orange.
				}
			}
			else
			{
				//Move one step closer to next spot
				if (bLoc < b.peek()) { bLoc++; }
				if (bLoc > b.peek()) { bLoc--; }
			}
		}
		
		if (taskPerformed) { tasks.pop(); }
		steps++;
		
		//System.out.println("Step=" + steps + "; O=" + oLoc + "; B=" + bLoc);
	}
	
	public int getSteps()
	{
		return steps;
	}
	
}
