package codejam2011.Round0.C;
import java.util.*;

public class Case
{
	List<Integer> candies;
	List<Integer> sean = new ArrayList<Integer>();
	List<Integer> pat = new ArrayList<Integer>();
	PriorityQueue<Integer> possibilities = new PriorityQueue<Integer>();
	
	public Case(Integer count, String input)
	{
		Scanner s = new Scanner(input);
		candies = new ArrayList<Integer>(count);
		
		while (s.hasNext())
		{
			candies.add(s.nextInt());
		}

		Collections.sort(candies);
		
		
					/*	//Pat's pile
						for (int k=0; k < i; k++)
						{
							pat.add(candies.get(m+k));
						}
						
						//Sean's pile
						for (int k=0; k < candies.size(); k++)
						{
							if (k < m || k >= m+i) {
								sean.add(candies.get(k));
							}
						}
						
						//Check if Pat's pile = Sean's pile
						if (xorPiles(pat, sean) && pat.size()>0 && sean.size()>0)
						{
							Integer total = 0;
							for (Integer x : sean)
							{
								total += x;
							}
							possibilities.offer(total);
						}
						else
						{
							pat.clear();
							sean.clear();
						}
	*/
		
		//System.out.println(candies.toString());
		//System.out.println("Pat : " + pat.toString());
		//System.out.println("Sean: " + sean.toString());
		//System.out.println("Possibilities: " + possibilities.toString());
	}
	
	private boolean xorPiles(List<Integer> a, List<Integer> b)
	{
		boolean retval = false;
		Integer aTotal = 0;
		Integer bTotal = 0;
		
		for (Integer i : a)
		{
			aTotal ^= i;
		}
		
		for (Integer i : b)
		{
			bTotal ^= i;
		}
		
		return retval;
	}
	
	private void rec(Map<Integer, String> piles)
	{
		//
	}
}
