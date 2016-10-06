using System;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol;
using Takenet.MessagingHub.Client;
using Takenet.MessagingHub.Client.Listener;
using Takenet.MessagingHub.Client.Sender;
using System.Diagnostics;
using Lime.Messaging.Contents;

namespace Decom_Bot
{
    public class PlainTextMessageReceiver : IMessageReceiver
    {
        private readonly IMessagingHubSender _sender;

        public PlainTextMessageReceiver(IMessagingHubSender sender)
        {
            _sender = sender;
        }

        public async Task ReceiveAsync(Message message, CancellationToken cancellationToken)
        {
            Console.WriteLine($"From: {message.From} \tContent: {message.Content}");
            switch (message.Content.ToString().ToLower())
            {
                case "iniciar":
                case "oi":
                case "inicio":
                case "hi":
                case "hello":
                case "decom":
                case "celebrations":
                    await OpenMainMenuAsync(message.From, cancellationToken);
                    break;
                case "comecar":
                case "começar":
                    await OpenStartMenuAsync(message.From, cancellationToken);
                    break;
                case "cursos":
                    await OpenCoursesMenuAsync(message.From, cancellationToken);
                    break;
                case "informações":
                case "informacoes":
                    await OpenInformationMenuAsync(message.From, cancellationToken);
                    break;
                case "contatos":
                    await OpenContactMenuAsync(message.From, cancellationToken);
                    break;
                case "email chefia":
                case "email eng. de comp.":
                case "email cursos tec":
                case "email laboratorios":
                case "email secretaria":
                    await OpenEmailMenuAsync(message.Content.ToString().ToLower(), message.From, cancellationToken);
                    break;
                case "informatica":
                    await OpenInformaticaMenuAsync(message.From, cancellationToken);
                    break;
                case "redes":
                    await OpenRedesMenuAsync(message.From, cancellationToken);
                    break;
                case "engenharia de computacao":
                    await OpenEngenhariaMenuAsync(message.From, cancellationToken);
                    break;
                default:
                    await OpenMainMenuAsync(message.From, cancellationToken);
                    break;
            };
        }

        private async Task OpenMainMenuAsync(Node from, CancellationToken cancellationToken)
        {
            var select = new Select
            {
                Text = "Olá, é um prazer conversar com vc! 😍"
                                    + "\n\nEu sou um chatbot e estou aqui para lhe ajudar a encontrar as principais informações sobre o DEpartamento de COMputação do CEFET-MG 🎓."
                                    + "\n\nEu fui construido para a celebração dos 10 anos do DECOM 🎉"
                                    + "\n\nPara que eu possa lhe ajudar clique no botão abaixo 👇!",
            };
            var selectOptions = new SelectOption[1];
            selectOptions[0] = new SelectOption
            {
                Text = "Começar",
                Order = 0,
                Value = new PlainText { Text = "Comecar" }
            };
            select.Options = selectOptions;
            await _sender.SendMessageAsync(select, from, cancellationToken);
        }

        private async Task OpenStartMenuAsync(Node from, CancellationToken cancellationToken)
        {
            var select = new Select
            {
                Text = "Antes de começar gostaria de dizer que estou em constante aprendizado 🚧... ah e sou um pouco tímido também 😅"
                    + "\n\nPara facilitar nossa conversa,  escolha sobre qual dos temas deseja saber:"
                    + "\n\n(💬... lembre-se basta clicar em uma das opções abaixo 👇)"
            };
            var selectOptions = new SelectOption[3];

            selectOptions[0] = new SelectOption
            {
                Text = "Cursos",
                Order = 0,
                Value = new PlainText { Text = "Cursos" }
            };
            selectOptions[1] = new SelectOption
            {
                Text = "Informações",
                Order = 1,
                Value = new PlainText { Text = "Informacoes" }
            };
            selectOptions[2] = new SelectOption
            {
                Text = "Contatos",
                Order = 2,
                Value = new PlainText { Text = "Contatos" }
            };
            select.Options = selectOptions;
            await _sender.SendMessageAsync(select, from, cancellationToken);
        }

        private async Task OpenCoursesMenuAsync(Node from, CancellationToken cancellationToken)
        {
            await _sender.SendMessageAsync("💡 O DECOM conta atualmente com os cursos técnicos de"
                                            + "\n\n✔️ Informática "
                                            + "\n✔️ Redes de Computadores"
                                            + "\n\nalém do curso de graduação em"
                                            + "\n✔️ Engenharia de Computação."
                                            + "Para saber mais sobre cada um dos cursos clique em um dos links abaixo 👇!", from, cancellationToken);
            var linkInf = new WebLink
            {
                Text = "Informática",
                Uri = new Uri("http://www.decom.cefetmg.br/site/tec_informatica/apresentacao.html")
            };
            await _sender.SendMessageAsync(linkInf, from, cancellationToken);
            var linkRdc = new WebLink
            {
                Text = "Redes de Computadores",
                Uri = new Uri("http://www.decom.cefetmg.br/site/tec_redes/apresentacao.html")
            };
            await _sender.SendMessageAsync(linkRdc, from, cancellationToken);
            var linkEng = new WebLink
            {
                Text = "Engenharia de Computação",
                Uri = new Uri("http://www.decom.cefetmg.br/site/eng_computacao/apresentacao.html")
            };
            await _sender.SendMessageAsync(linkEng, from, cancellationToken);
        }

        private async Task OpenInformationMenuAsync(Node from, CancellationToken cancellationToken)
        {
            var select = new Select
            {
                Text = "O DECOM possui atualmente 3 cursos, 2 técnicos e 1 graduação."
            };
            var selectOptions = new SelectOption[3];
            selectOptions[0] = new SelectOption
            {
                Text = "Técnico em Informática",
                Order = 0,
                Value = new PlainText { Text = "informatica" }
            };
            selectOptions[1] = new SelectOption
            {
                Text = "Técnico em Redes",
                Order = 1,
                Value = new PlainText { Text = "redes" }
            };
            selectOptions[2] = new SelectOption
            {
                Text = "Engenharia de Computação",
                Order = 2,
                Value = new PlainText { Text = "engenharia de computacao" }
            };
            select.Options = selectOptions;
            await _sender.SendMessageAsync(select, from, cancellationToken);
        }

        private async Task OpenInformaticaMenuAsync(Node from, CancellationToken cancellationToken)
        {
            await _sender.SendMessageAsync("💡 O nosso curso de Informática começou a funcionar em 1989, com 40 alunos. Era um curso técnico e Informática Industrial, focando em desenvolvimento de software e também em eletrônica. A partir de 2010, o curso sofreu modificações profundas, foi ampliado e passou a ser chamado de Técnico de Informática", from, cancellationToken);

            await _sender.SendMessageAsync("Olha só quanta coisa bacana eu sei sobre o curso de informática... 👏", from, cancellationToken);

            var documentCollection = new DocumentCollection
            {
                Items = new DocumentSelect[]
                {
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/calendarios/calendario_escolar_integrado.pdf"),
                                Text = "Fique atento, não perca nenhuma aula e aproveite muito todos os feriados 😊",
                                Title = "Calendário escolar"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/horarios/tec_informatica/horarios_tec_informatica.zip"),
                                Text = "Não importa se vc é da INF01, 2 ou 3... aqui estão todos os horários 😉",
                                Title = "Horário das aulas"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/galerias/arquivos_download/outros/matriz_curricular-Informatica.pdf"),
                                Text = "Encontre todas as disciplinas e suas dependências aqui na matriz currícular!",
                                Title = "Matriz currícular"
                            }
                        }
                    }
                },
                ItemType = DocumentSelect.MediaType
            };

            await _sender.SendMessageAsync(documentCollection, from, cancellationToken);

        }

        private async Task OpenRedesMenuAsync(Node from, CancellationToken cancellationToken)
        {
            await _sender.SendMessageAsync("💡 O nosso curso de Redes de Computadores foi formado em 2009 partir de modificações profundas no antigo curso de Informática Industrial. Formado pela necessidade do mercado de profissionais habilitados para configurar e dar manutenção dispositivos de comunicação e softwares em equipamentos de redes", from, cancellationToken);

            await _sender.SendMessageAsync("Olha só quanta coisa bacana eu sei sobre o curso de informática... 👏", from, cancellationToken);

            var documentCollection = new DocumentCollection
            {
                Items = new DocumentSelect[]
                {
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/calendarios/calendario_escolar_integrado.pdf"),
                                Text = "Fique atento, não perca nenhuma aula e aproveite muito todos os feriados 😊",
                                Title = "Calendário escolar"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/horarios/tec_informatica/horarios_tec_informatica.zip"),
                                Text = "Não importa se vc é da INF01, 2 ou 3... aqui estão todos os horários 😉",
                                Title = "Horário das aulas"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/galerias/arquivos_download/outros/matriz_curricular-Informatica.pdf"),
                                Text = "Encontre todas as disciplinas e suas dependências aqui na matriz currícular!",
                                Title = "Matriz currícular"
                            }
                        }
                    }
                },
                ItemType = DocumentSelect.MediaType
            };

            await _sender.SendMessageAsync(documentCollection, from, cancellationToken);
        }

        private async Task OpenEngenhariaMenuAsync(Node from, CancellationToken cancellationToken)
        {
            await _sender.SendMessageAsync("💡 O nosso curso de Graduação em Engenharia de Computação é ofertado desde o primeiro semestre de 2007 e possui sólida formação técnico-científica que capacita os alunos a projetar e desenvolver sistemas computacionais de hardware e software", from, cancellationToken);

            await _sender.SendMessageAsync("Olha só quanta coisa bacana eu sei sobre o curso de informática... 👏", from, cancellationToken);

            var documentCollection = new DocumentCollection
            {
                Items = new DocumentSelect[]
                {
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/calendarios/calendario_escolar_integrado.pdf"),
                                Text = "Fique atento, não perca nenhuma aula e aproveite muito todos os feriados 😊",
                                Title = "Calendário escolar"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/site/alunos/arquivos_downloads/horarios/tec_informatica/horarios_tec_informatica.zip"),
                                Text = "Não importa se vc é da INF01, 2 ou 3... aqui estão todos os horários 😉",
                                Title = "Horário das aulas"
                            }
                        }
                    },
                    new DocumentSelect
                    {
                        Header = new DocumentContainer
                        {
                            Value = new WebLink
                            {
                                Uri = new Uri("http://decom.cefetmg.br/galerias/arquivos_download/outros/matriz_curricular-Informatica.pdf"),
                                Text = "Encontre todas as disciplinas e suas dependências aqui na matriz currícular!",
                                Title = "Matriz currícular"
                            }
                        }
                    }
                },
                ItemType = DocumentSelect.MediaType
            };

            await _sender.SendMessageAsync(documentCollection, from, cancellationToken);
        }

        private async Task OpenContactMenuAsync(Node from, CancellationToken cancellationToken)
        {
            var select = new Select
            {
                Text = "O endereço do DECOM é:"
                    + "\n\n🏢Av.Amazonas 7675 - Nova Gameleira - Belo Horizonte - MG - Brasil"
                    + "\n☎️+55(31) 3319 - 6870"
                    + "\n\nEu conheço também alguns emails que podem lhe ser úteis."
            };
            var selectOptions = new SelectOption[5];

            selectOptions[0] = new SelectOption
            {
                Text = "Chefia do Departamento",
                Order = 0,
                Value = new PlainText { Text = "Email Chefia" }
            };
            selectOptions[1] = new SelectOption
            {
                Text = "Coordenação de Eng. de Comp.",
                Order = 1,
                Value = new PlainText { Text = "Email Eng. de Comp." }
            };
            selectOptions[2] = new SelectOption
            {
                Text = "Coordenação Cursos Téc.",
                Order = 2,
                Value = new PlainText { Text = "Email Cursos Tec" }
            };
            selectOptions[3] = new SelectOption
            {
                Text = "Laboratórios DECOM",
                Order = 3,
                Value = new PlainText { Text = "Email Laboratorios" }
            };
            selectOptions[4] = new SelectOption
            {
                Text = "Secretaria DECOM",
                Order = 4,
                Value = new PlainText { Text = "Email Secretaria" }
            };
            select.Options = selectOptions;
            await _sender.SendMessageAsync(select, from, cancellationToken);
        }

        private async Task OpenEmailMenuAsync(String content, Node from, CancellationToken cancellationToken)
        {
            switch (content)
            {
                case "email chefia":
                    await _sender.SendMessageAsync("📧 Chefia do Departamento"
                                                + "\nchefiadepart@decom.cefetmg.br", from, cancellationToken);
                    break;
                case "email eng. de comp.":
                    await _sender.SendMessageAsync("📧 Coordenação do Curso de Engenharia de Computação"
                                                + "\ncoordengcomp@decom.cefetmg.br", from, cancellationToken);
                    break;
                case "email cursos tec":
                    await _sender.SendMessageAsync("📧 Coordenação dos cursos técnicos"
                                                + "\ncoordinf@decom.cefetmg.br", from, cancellationToken);
                    break;
                case "email laboratorios":
                    await _sender.SendMessageAsync("📧 Laboratórios do DECOM"
                                                + "\ncoordlab@decom.cefetmg.br", from, cancellationToken);
                    break;
                case "email secretaria":
                    await _sender.SendMessageAsync("📧 Secretaria do DECOM"
                                                + "\ndecom@decom.cefetmg.br", from, cancellationToken);
                    break;
            }
        }
    }
}
