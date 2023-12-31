﻿using ProjetoAula04.Enums;
using System.Text.RegularExpressions;

namespace ProjetoAula04.Entities
{
    public class Funcionario
    {
        private Guid _id;
        private string _nome;
        private string _Cpf;
        private string _matricula;
        private DateTime _dataAdmissao;
        private TipoContratacao _tipoContratacao;

        public Guid Id
        {
            set
            {
                if (value == Guid.Empty) throw new ArgumentException("O ID do funcionário não pode ser vazio");

                _id = value;
            }
            get { return _id; }
        }

        public string Nome
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("O nome do funcionário é obrigatório");

                var regex = new Regex("^[A-Za-zÀ-Üà-ü\\s]{8,100}$");
                if (!regex.IsMatch(value)) throw new ArgumentException("Informe um nome válido de 8 a 100 caracteres");

                _nome = value;
            }
            get { return _nome; }
        }

        public string Cpf
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("O Cpf do funcionário é obrigatório");

                var regex = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
                if (!regex.IsMatch(value)) throw new ArgumentException("Informe um Cpf no formato: '999.999.999-99'");

                _Cpf = value;
            }
            get { return _Cpf; }
        }

        public string Matricula
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("A Mátricula do funcionário é obrigatória");

                var regex = new Regex("^[A-Z0-9]{6,10}$");
                if (!regex.IsMatch(value)) throw new ArgumentException("Informe a matrícula somente com letras maiusculas, numeros e de 6 a 10 caracteres.");

                _matricula = value;
            }
            get { return _matricula; }
        }

        public DateTime DataAdmissao
        {
            set
            {
                if (value == null) throw new ArgumentException("A Data de admissão do funcionário é obrigatória");

                _dataAdmissao = value;
            }
            get { return _dataAdmissao; }
        }

        public TipoContratacao TipoContratacao
        {
            set
            {
                if (value == null) throw new ArgumentException("O tipo de contratação do funcionário é obrigatório");

                _tipoContratacao = value;
            }
            get { return _tipoContratacao; }
        }
    }
}