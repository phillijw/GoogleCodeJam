package codejam2010.round0.a;

import java.util.Observable;

public class EntryPoint {

	/**
	 * @param args
	 */
	public static void main(String[] args)
	{
		Outlet outlet = new Outlet();
		Lamp lamp;
		
		//Case #1: OFF
		//Input: Snappers(N)=1, Snaps(K)=0
		lamp = new Lamp();
		Snapper s1 = new Snapper(outlet, lamp);
		System.out.println("Case #1: " + (lamp.hasPower() ? "ON" : "OFF"));
		
		//Case #2: ON
		//Input: Snappers(N)=1, Snaps(K)=1
		lamp = new Lamp();
		Snapper s2 = new Snapper(outlet, lamp);
		s2.clap();
		s2.commit();
		Observable o = new Observable();
		
		System.out.println("Case #2: " + (lamp.hasPower() ? "ON" : "OFF"));
	}

}
