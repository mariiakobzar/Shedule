package md56a462996b33a3e9d22f9d04f97ec7ebe;


public class DayAppointmentLayout
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMeasure:(II)V:GetOnMeasure_IIHandler\n" +
			"n_onLayout:(ZIIII)V:GetOnLayout_ZIIIIHandler\n" +
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Schedule.DayAppointmentLayout, Syncfusion.SfSchedule.Android", DayAppointmentLayout.class, __md_methods);
	}


	public DayAppointmentLayout (android.content.Context p0)
	{
		super (p0);
		if (getClass () == DayAppointmentLayout.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Schedule.DayAppointmentLayout, Syncfusion.SfSchedule.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public DayAppointmentLayout (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == DayAppointmentLayout.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Schedule.DayAppointmentLayout, Syncfusion.SfSchedule.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public DayAppointmentLayout (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == DayAppointmentLayout.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Schedule.DayAppointmentLayout, Syncfusion.SfSchedule.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public DayAppointmentLayout (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == DayAppointmentLayout.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Schedule.DayAppointmentLayout, Syncfusion.SfSchedule.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onMeasure (int p0, int p1)
	{
		n_onMeasure (p0, p1);
	}

	private native void n_onMeasure (int p0, int p1);


	public void onLayout (boolean p0, int p1, int p2, int p3, int p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (boolean p0, int p1, int p2, int p3, int p4);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}