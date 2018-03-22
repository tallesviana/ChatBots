using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Remedios.Models
{
    public class RemedioRepositorio : IRemedioRepositorio
    {
        private List<Remedio> remedios = new List<Remedio>();
        private int _nextId = 1;

        public RemedioRepositorio()
        {
            Add(new Remedio { Nome = "Dipirona",
                Indicacao = "Indicado para aliviar a dor e para baixar a febre.",
                Posologia = "Adultos e adolescentes acima de 15 anos devem tomar 10 a 20 mL em dose única, 4 vezes ao dia.",
                Efeitos = "- Os efeitos colaterais mais frequentes são alergia com coceira, ardor, vermelhidão, urticária, inchaço ou falta de ar, alterações no batimento cardíaco e nos valores do exame de sangue, podendo aparecer anemia.",
                Preco = "O preço gira em torno de R$ 5,00 e R$ 6,00."});
            Add(new Remedio { Nome = "Cataflan Gotas",
                Indicacao = "Indicado para aliviar a dor causada por artrite juvenil crônica, entorses, inflamação no pós-operatório, infeções do nariz, ouvido ou garganta ou problemas ginecológicos como cólica menstrual.",
                Posologia = "A dose deve ser indicada pelo médico de acordo com a gravidade da doença e a idade, podendo ser: \n\n**Crianças entre 1 ano e 13 anos**: 1 a 4 gotas por kg de peso corpóreo diariamente, divididas em 2 ou 3 doses separadas.\n\n**Adolescentes com mais de 14 anos**: 150 a 200 gotas diariamente, dividida em 2 ou 3 doses.\n\n**Adultos**: 200 a 300 gotas diariamente, dividida em 2 ou 3 doses.\nEm casos mais leves, 150 a 200 gotas diárias podem ser suficientes em adultos.",
                Efeitos = "Os efeitos colaterais mais comuns são dor de cabeça, tontura, náusea, vômito, diarreia, dor abdominal, flatulência, perda do apetite, alterações nos valores do fígado no exame de sangue, vermelhidão na pele com ou sem descamação.",
                Preco = "O preço gira em torno de R$20,00 e R$30,00."});
            Add(new Remedio { Nome = "Dramin Comprimidos",
                Indicacao = "Indicado para: Náuseas e vômitos da gravidez; Prevenção e tratamento do enjoo de movimento; Prevenção e tratamento da vertigem e alterações do equilíbrio; Perturbações observadas após tratamentos radioterápicos intensivos; Prevenção e tratamento das náuseas e vômitos no pré e pós-operatórios; Tratamento das labirintites e dos estados vertiginosos de origem central.",
                Posologia = "Adultos e adolescentes acima de 12 anos: ½ a 1 comprimido a cada 4 a 6 horas, não excedendo 4 comprimidos em 24 horas.",
                Efeitos = "Os efeitos secundários são em geral leves e incluem sonolência, sedação e até mesmo sono, variando sua incidência e intensidade de pessoa para pessoa, raramente requerendo a suspensão da medicação. Pode ocorrer também tontura, turvação visual, insônia, nervosismo, secura da boca, da garganta, das vias respiratórias e retenção urinária.",
                Preco = "O preço gira em torno de R$5,00 e R$7,00."
            });
            Add(new Remedio { Nome = "Aspirina",
                Indicacao = "Indicado para aliviar vários tipos de dor, como dor de cabeça, dor de dente, dor de garganta, dor menstrual, dor muscular, dor nas articulações, dor nas costas ou dor da artrite. Além disso, também pode ser usada para aliviar os sintomas associados a febre nos resfriados e gripe.",
                Posologia = "A dosagem e duração do tratamento devem ser sempre indicados pelo médico, sendo normalmente: \n\n**Crianças a partir dos 12 anos**: 1 comprimido, se necessário repetido a cada 4 a 8 horas. Não se deve administrar mais de 3 comprimidos por dia.\n\n **Adultos**: recomendam-se 1 a 2 comprimidos, se necessário repetidos a cada 4 a 8 horas. Evitando tomar mais de 8 comprimidos por dia.\n\nDeve-se tomar após as refeições, nunca com estômago vazio.",
                Efeitos = "Os efeitos colaterais são dor de estômago, náuseas, vômitos ou diarreia, sangramentos, aumento da acidez no estômago, zumbido no ouvido, tontura ou reações de alergia na pele, como vermelhidão, coceira e inchaço na pele.",
                Preco = "O preço gira em torno de R$7,00 e R$10,00"
            });
            Add(new Remedio { Nome = "Omeprazol",
                Indicacao = "Omeprazol é indicado no tratamento de casos em que ocorra uma produção excessiva de ácido no estômago, como úlceras no estômago e intestinos, refluxo gastroesofágico ou doença de Zollinger-Ellison, e no tratamento de úlceras associadas a infecções causadas pela bactéria Helycobacter pylori, em adultos e crianças. Além disso, também é indicado no tratamento da dispepsia e pode ser utilizado para prevenir sangramento do trato gastrintestinal superior em pacientes gravemente doentes.",
                Posologia = "Geralmente, a dose recomendada de Omeprazol varia entre os 10 mg e os 20 mg, administrados antes do café da manhã e durante um período que pode ir da toma única até as 4 semanas de tratamento. A dose recomendada e a duração do tratamento devem ser indicadas pelo seu médico, pois vão depender do problema a tratar e da idade e resposta individual do paciente. As cápsulas de Omeprazol devem ser engolidas juntamente com um copo de água, imediatamente antes das refeições e de preferência logo pela manhã. Caso seja necessário, as cápsulas podem ser abertas, e o seu conteúdo pode ser misturado com água ou suco para facilitar a ingestão do remédio. De acordo com indicação médica, Omeprazol pode ser administrado sozinho ou em conjunto com outros remédios antiácidos.",
                Efeitos = "Alguns dos efeitos colaterais de Omeprazol mais comuns podem incluir dor de cabeça, diarreia, prisão de ventre, dor abdominal, náusea, gases, vômito, refluxo, infecção respiratória, tontura, erupção na pele, fraqueza excessiva, dor nas costas ou tosse.",
                Preco = "O preço gira em torno de R$15,00 e R$30,00"
            });

        }

        public Remedio Add(Remedio item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            remedios.Add(item);
            return item;
        }

        public Remedio Get(int id)
        {
            return remedios.Find(r => r.Id == id);
        }

        public IEnumerable<Remedio> GetAll()
        {
            return remedios;
        }

        public void Remove(int id)
        {
            remedios.RemoveAll(r => r.Id == id);
        }

        public bool Update(Remedio item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = remedios.FindIndex(r => r.Id == item.Id);

            if(index == -1)
            {
                return false;
            }

            remedios.RemoveAt(index);
            remedios.Add(item);
            return true;
        }
    }
}