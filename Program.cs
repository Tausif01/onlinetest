using System;


public interface ICoin
{
	string Description { get; set; }
	decimal value1{get;set;}
	
}

public class nickelsCoin: ICoin
{
    string ICoin.Description{get;set;}
	decimal ICoin.value1{get;set;} = 1/20;
}
public class dimesCoint: ICoin
{
    string ICoin.Description{get;set;}
	decimal ICoin.value1{get;set;} = 1/10;
}
public class quartersCoin: ICoin
{
    string ICoin.Description{get;set;}
	decimal ICoin.value1{get;set;} = 1/4;
}

public interface IVendorOperation
{	
    public decimal sumvalue{get;set;}
	public int coincounter{get;set;}
	public int AcceptCoin(ICoin c);
	public decimal insert(ICoin c);
	
}

public class VendorOperation:IVendorOperation
{
	public decimal sumvalue{get;set;}
	public int coincounter{get;set;}
	public VendorOperation()
	{
		sumvalue=0;
		coincounter=0;
	}
    
   
	public int AcceptCoin(ICoin c)
	{
		if(c is nickelsCoin || c is dimesCoint || c is quartersCoin)
			return 1;
		else	
			return 0;
	}
	public decimal insert(ICoin c)
	{
		coincounter+=1;
		return sumvalue +=c.value1;
	}
}

public interface IVendorProduct
{
	public string Description { get; set; }
	public decimal value1{get;set;}	
}

public class cola: IVendorProduct
{
	public string Description { get; set; }
	public decimal value1{get;set;}=1.0m;
}

public class chips: IVendorProduct
{
	public string Description { get; set; }
	public decimal value1{get;set;}=0.5m;
}

public class candy: IVendorProduct
{
	public string Description { get; set; }
	public decimal value1{get;set;}=0.65m;
}

public interface IVendorSelectProduct
{
	public IVendorProduct selectCandy();
	public IVendorProduct selectcola();
	public IVendorProduct selectchips();
}

public class VendorSelectProduct:IVendorSelectProduct
{
	IVendorOperation op;
	public VendorSelectProduct(IVendorOperation vp)
	{
		op=vp;
	}
	IVendorProduct selectprod=null;
	public IVendorProduct selectCandy()
	{
	    selectprod=new candy();
		if(op.sumvalue >=selectprod.value1)
		{
			op.sumvalue=op.sumvalue-selectprod.value1;
			return selectprod;
		}
		else	
			return null;
		
	}
	public IVendorProduct selectcola()
	{
	   selectprod=new cola();
	   if(op.sumvalue >=selectprod.value1)
		{
			op.sumvalue=op.sumvalue-selectprod.value1;
			return selectprod;
		}
		else	
			return null;
	}
	public IVendorProduct selectchips()
	{
	  selectprod=new chips();
	  if(op.sumvalue >=selectprod.value1)
		{
			op.sumvalue=op.sumvalue-selectprod.value1;
			return selectprod;
		}
		else	
			return null;
	}
}




public class Program
{
	public static void Main()		
	{
		
		IVendorOperation vendormachine= new VendorOperation();
		if(vendormachine.coincounter==0)
			Console.WriteLine("INSERT COINT");
		
		ICoin cointoinsert=new nickelsCoin();
		decimal balance=0;
		int isaccepted=vendormachine.AcceptCoin(cointoinsert);
		if(isaccepted>0)
			balance = vendormachine.insert(cointoinsert);
		Console.WriteLine("Total amount as of now" + balance);
		
		IVendorSelectProduct sel= new VendorSelectProduct( vendormachine);
		IVendorProduct output=sel.selectCandy();
		if(output ==null)
		{	
			Console.WriteLine("INSERT COIN");
		}
		
	}
	
}