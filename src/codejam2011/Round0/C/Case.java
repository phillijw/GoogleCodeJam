package codejam2011.Round0.C;
import java.util.*;

public class Case
{
	private int seansSum;
	private List<Integer> candies;
	private boolean isCrying = true;
	
	public Case(Integer count, String input)
	{
		Scanner s = new Scanner(input);
		candies = new ArrayList<Integer>(count);
		
		while (s.hasNext())
		{
			candies.add(s.nextInt());
		}

		Collections.sort(candies);
		
		//Pat's piece of candy
		int patsXorSum = candies.get(0);
		
		//Sean's candies
		int seansXorSum = 0;
		seansSum = 0;
		for (int i=1; i < candies.size(); i++)
		{
			seansXorSum ^= candies.get(i);
			seansSum += candies.get(i); 
		}
		
		if (patsXorSum == seansXorSum)
		{
			isCrying = false;
		}
	}
	
	public boolean isCrying()
	{
		return isCrying;
	}
	
	public int getSeansSum()
	{
		return this.seansSum;
	}
}
