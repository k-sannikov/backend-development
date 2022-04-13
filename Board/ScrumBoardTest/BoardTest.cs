using Xunit;
using System.Collections.Generic;
using ScrumBoard.Task;
using ScrumBoard.Column;
using ScrumBoard.Board;
using ScrumBoard.Exception;

namespace ScrumBoardTest
{
    public class BoardTest
    {
        [Fact]
        public void CreateBoard_WithProperties()
        {
            //����������
            string boardName = "�������� �����";
            //��������
            IBoard board = new Board(boardName);
            //��������
            Assert.Equal(boardName, board.Name);
            Assert.Empty(board.GetAllColumn());
        }

        [Fact]
        public void AddColumn_InBoard_ColumnWillBeAdded()
        {
            //����������
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            //��������
            board.AddColumn(column);
            //��������
            Assert.Equal(column, board.GetAllColumn()[0]);
        }

        [Fact]
        public void AddExistColumn_InBoard_ReturnExeption()
        {
            //����������
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            //��������/��������
            Assert.Throws<ColumnExistException>(() => board.AddColumn(column));
        }

        [Fact]
        public void EditColumnName_InBoard_ColumnNameWillChange()
        {
            //����������
            string newColumnName = "����� �������� �������";
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            //��������
            board.EditColumnName(column.GUID, newColumnName);
            //��������
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void EditNotExistColumnName_InBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<ColumnNotFoundException>(() => board.EditColumnName("", "����� �������� �������"));
        }

        [Fact]
        public void AddTask_OnBoardInDefaultColumn_TaskWillBeAdded()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            //��������
            board.AddTask(task);
            //��������
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void AddTask_OnBoardInSpecificColumn_TaskWillBeAdded()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column1 = new Column("�������� �������1");
            IColumn column2 = new Column("�������� �������2");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column1);
            board.AddColumn(column2);
            //��������
            board.AddTask(task, 1);
            //��������
            Assert.Equal(task, column2.GetAllTask()[0]);
        }

        [Fact]
        public void AddTask_OnBoardInNotExistColumn_ReturnExeption()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<ColumnNotFoundException>(() => board.AddTask(task, 5));
        }

        [Fact]
        public void GetTask_FromBoard_ReturnTask()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            board.AddTask(task);
            //��������
            ITask retTask = board.GetTask(task.GUID);
            //��������
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void GetNotExistTask_FromBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(""));
        }

        [Fact]
        public void GetColumn_FromBoard_ReturnColumn()
        {
            //����������
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            //��������
            IColumn retColumn = board.GetColumn(column.GUID);
            //��������
            Assert.Equal(column, retColumn);
        }

        [Fact]
        public void GetNotExistColumn_FromBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(""));
        }

        [Fact]
        public void GetAllColumn_FromBoard_ReturnAllColumn()
        {
            //����������
            IColumn column1 = new Column("�������� �������1");
            IColumn column2 = new Column("�������� �������2");
            IColumn column3 = new Column("�������� �������3");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddColumn(column3);
            //��������
            List<IColumn> columnList = board.GetAllColumn();
            //��������
            Assert.Equal(new List<IColumn>() { column1, column2, column3 }, columnList);
        }

        [Fact]
        public void EditTask_OnBoard_TaskWillChange()
        {
            //����������
            string newTaskName = "����� ������";
            string newTaskDescription = "����� �������� ������";
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            column.AddTask(task);
            board.AddColumn(column);
            //��������
            board.EditTask(task.GUID, newTaskName, newTaskDescription, TaskPriority.High);
            //��������
            ITask retTask = board.GetTask(task.GUID);
            Assert.Equal(newTaskName, retTask.Name);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.High, retTask.Priority);
        }

        [Fact]
        public void EditNotExistTask_OnBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<TaskNotFoundException>(() => board.EditTask("", "", "", TaskPriority.High));
        }

        [Fact]
        public void DeleteTask_OnBoard_TaskWillDelete()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            column.AddTask(task);
            board.AddColumn(column);
            //��������
            board.DeleteTask(task.GUID);
            //��������
            Assert.Throws<TaskNotFoundException>(() => board.GetTask(task.GUID));
        }

        [Fact]
        public void DeleteNotExistTask_OnBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<TaskNotFoundException>(() => board.DeleteTask(""));
        }

        [Fact]
        public void DeleteColumn_OnBoard_ColumnWillDelete()
        {
            //����������
            IColumn column = new Column("�������� �������");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column);
            //��������
            board.DeleteColumn(column.GUID);
            //��������
            Assert.Throws<ColumnNotFoundException>(() => board.GetColumn(column.GUID));
        }

        [Fact]
        public void DeleteNotExistColumn_OnBoard_ReturnExeption()
        {
            //����������
            IBoard board = new Board("�������� �����");
            //��������/��������
            Assert.Throws<ColumnNotFoundException>(() => board.DeleteColumn(""));
        }

        [Fact]
        public void TaskTransfer_OnBoard_ColumnWillDelete()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column1 = new Column("�������� �������1");
            IColumn column2 = new Column("�������� �������2");
            IBoard board = new Board("�������� �����");
            board.AddColumn(column1);
            board.AddColumn(column2);
            board.AddTask(task);
            //��������
            board.TaskTransfer(column2.GUID, task.GUID);
            //��������
            Assert.Empty(board.GetColumn(column1.GUID).GetAllTask());
            Assert.Equal(task, board.GetColumn(column2.GUID).GetTask(task.GUID));
        }
    }
}