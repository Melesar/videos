namespace App
{
	public interface ICommand
	{
		void Execute();
	}

	public interface ICommand<in T>
	{
		void Execute(T payload);
	}
	
	public interface ICommand<in T1, in T2>
	{
		void Execute(T1 arg1, T2 arg2);
	}
}
