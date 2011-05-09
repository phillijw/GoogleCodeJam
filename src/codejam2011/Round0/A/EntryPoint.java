package codejam2011.Round0.A;
import java.io.*;
import java.util.*;

public class EntryPoint
{
	public static void main(String[] args)
	{
		if (args.length == 0)
		{
			System.out.println("Must specify file.");
			System.exit(0);
		}

		File file = new File(args[0]);
		ArrayList<Case> cases = new ArrayList<Case>();

		try {
			Scanner s = new Scanner(file);
			if (s.hasNextLine()) { s.nextLine(); }
			while (s.hasNextLine()) {
				String line = s.nextLine();
				cases.add(new Case(line));
			}
		}
		catch (Exception e)
		{
			e.printStackTrace();
		}
	
		for(int i=0; i < cases.size(); i++)
		{
			System.out.println("Case #" + (i+1) + ": " + cases.get(i).getSteps());
		}
	}
}
