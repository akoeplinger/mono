// Compiler options: -t:library -warnaserror
using System.Threading;

public class Test
{
	volatile int foo;

	void Bar ()
	{
		Interlocked.CompareExchange (ref foo, 0, 1);
	}
}
