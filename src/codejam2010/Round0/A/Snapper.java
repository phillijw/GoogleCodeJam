package codejam2010.Round0.A;

import java.util.Observable;
import java.util.Observer;

public class Snapper implements Device, Observer
{
	private boolean changed;
	private boolean hasPower;
	private boolean willHavePower;
	private boolean stateIsOn;
	private boolean stateWillBeOn;
	private Device inputDevice;
	private Device outputDevice;
	
	public Snapper(Device in, Device out)
	{
		changed = false;
		hasPower = false;
		willHavePower = false;
		stateIsOn = false;
		stateWillBeOn = false;
		inputDevice = in;
		outputDevice = out;
	}
	
	public void clap()
	{
		if (hasPower) stateWillBeOn = !stateIsOn;
	}

	public void commit()
	{
		if (changed)
		{
			hasPower = willHavePower;
			stateIsOn = stateWillBeOn;
			changed = false;
		}
	}
	
	public final boolean stateIsOn()
	{
		return stateIsOn;
	}
	
	public final boolean hasPower()
	{
		return hasPower;
	}

	public void update(Observable o, Object arg)
	{
		
	}
}

