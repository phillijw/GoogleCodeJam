package codejam2011.Round0.B;
import java.util.*;

public class Case
{
	Map<String, Set<String>> opposed = new HashMap<String, Set<String>>();
	Map<String, String> combos = new HashMap<String, String>();
	Deque<String> series = new LinkedList<String>();
	Stack<String> result = new Stack<String>();
	
	public Case(String input)
	{
		Scanner s = new Scanner(input);
		
		//Store combos
		int c = s.nextInt();
		for (int i=0; i < c; i++)
		{
			String str = s.next();
			String one = str.substring(0, 1);
			String two = str.substring(1, 2);
			String three = str.substring(2, 3);
			
			combos.put(order(one+two), three);
		}
		
		//Store opposed
		int d = s.nextInt();
		for (int i=0; i < d; i++)
		{
			String str = s.next();
			if (opposed.containsKey(str.substring(0, 1)))
			{
				opposed.get(str.substring(0, 1)).add(str.substring(1, 2));
			}
			else
			{
				Set<String> tmpSet = new HashSet<String>();
				tmpSet.add(str.substring(1, 2));
				opposed.put(str.substring(0, 1), tmpSet);				
			}
			
			if (opposed.containsKey(str.substring(1, 2)))
			{
				opposed.get(str.substring(1, 2)).add(str.substring(0, 1));
			}
			else
			{
				Set<String> tmpSet = new HashSet<String>();
				tmpSet.add(str.substring(0, 1));
				opposed.put(str.substring(1, 2), tmpSet);				
			}
		}
		
		//Store series
		int n = s.nextInt();
		String str = s.next();
		for (int i=0; i < n; i++)
		{
			series.addLast(str.substring(i, i+1));		
		}
		
		//Do checks
		int ssize = series.size();
		for (int i=0; i < ssize; i++)
		{
			String newLetter = series.pollFirst();
			if (result.empty()) { result.push(newLetter); continue; }
			String prevLetter = result.peek();
			
			if (combos.containsKey(order(newLetter+prevLetter)))
			{
				newLetter = combos.get(order(newLetter+prevLetter));
				result.pop();
				result.push(newLetter);
			}
			else if (opposed.containsKey(newLetter))
			{
				boolean hasOpposed = false;
				
				for(String letter : opposed.get(newLetter))
				{
					if (result.contains(letter))
					{
						result.clear();
						hasOpposed = true;
						break;
					}
				}
				
				if (!hasOpposed)
				{
					result.push(newLetter);
				}

			}
			else
			{
				result.push(newLetter);
			}
		}
	}
	
	private String order(String str)
	{
		String retVal = "";
		String one = str.substring(0, 1);
		String two = str.substring(1, 2);
		
		if (one.compareTo(two) > 0) { retVal = one+two; }
		if (two.compareTo(one) > 0) { retVal = two+one; }
		if (one.compareTo(two) == 0) { retVal = str; }
		
		return retVal;
	}
	
	public String getResults()
	{
		return result.toString();
	}
}
