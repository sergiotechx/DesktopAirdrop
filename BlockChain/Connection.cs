using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Numerics;

namespace BlockChain
{
    public class Connection
    {
        private Web3 web3;
        private Account account;
        private string abi;
        private string contractAdress;
        private Nethereum.Contracts.Contract contract;



        public Connection(string _strconnection, string _privatekey, string _contractAdress,int _ChainId)
        {
            account = new Account(_privatekey, new BigInteger(_ChainId));
            web3 = new Web3(account, _strconnection);
            web3.TransactionManager.UseLegacyAsDefault = true;
            contractAdress = _contractAdress;
            var abi =
            @"[{""constant"":false,""inputs"":[{""name"":""_spender"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{""name"":""supply"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_from"",""type"":""address""},{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_to"",""type"":""address""},{""name"":""_value"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":""success"",""type"":""bool""}],""type"":""function""},{""constant"":true,""inputs"":[{""name"":""_owner"",""type"":""address""},{""name"":""_spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""type"":""function""},{""inputs"":[{""name"":""_initialAmount"",""type"":""uint256""}],""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_from"",""type"":""address""},{""indexed"":true,""name"":""_to"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_owner"",""type"":""address""},{""indexed"":true,""name"":""_spender"",""type"":""address""},{""indexed"":false,""name"":""_value"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""}]";
            contract = web3.Eth.GetContract(abi, contractAdress);
        }

        public async Task<decimal> NativeTBalance(string Account)
        {
            var balance = await web3.Eth.GetBalance.SendRequestAsync(Account);
            return Web3.Convert.FromWei(balance.Value);
        }

        public async Task<decimal> TBalance(string account)
        {

            var function = contract.GetFunction("balanceOf");
            BigInteger balance = await function.CallAsync<BigInteger>(account);
            return Web3.Convert.FromWei(balance);

        }

        public async Task<Nethereum.Web3.Accounts.Account> AccountCreation()
        {
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
            var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
            return new Nethereum.Web3.Accounts.Account(privateKey, 97);
        }
        public async Task<Nethereum.RPC.Eth.DTOs.TransactionReceipt> SendNativeT(string toAddress, decimal amount)
        {
            
            var transaction = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(toAddress, amount);
            
            return transaction;
        }
        public async Task<string> SendT(string toAddress, decimal amount)
        {


            try
            {
                var transferFunction = contract.GetFunction("transfer");
                BigInteger amountToSend = Web3.Convert.ToWei(amount);
                var gas = await transferFunction.EstimateGasAsync(account.Address, null, null, toAddress, amountToSend);

                var transaction = await transferFunction.SendTransactionAndWaitForReceiptAsync(account.Address, gas, null, null, toAddress, amountToSend);

                return transaction.TransactionHash;
            }
            catch (Exception ex)
            {
              throw new Exception(ex.Message);
            }
            
        }

    }
}