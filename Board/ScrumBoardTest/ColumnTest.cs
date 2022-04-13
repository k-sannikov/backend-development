using Xunit;
using System.Collections.Generic;
using ScrumBoard.Task;
using ScrumBoard.Column;

namespace ScrumBoardTest
{
    public class ColumnTest
    {
        [Fact]
        public void CreateColumn_WithProperties()
        {
            //����������
            string columnName = "�������� �������";
            //��������
            IColumn column = new Column(columnName);
            //��������
            Assert.False(string.IsNullOrEmpty(column.GUID));
            Assert.Equal(columnName, column.Name);
            Assert.Empty(column.GetAllTask());
        }

        [Fact]
        public void ChangeColumnName_NameWillChange()
        {
            //����������
            string newColumnName = "����� �������� �������";
            IColumn column = new Column("�������� �������");
            //��������
            column.Name = newColumnName;
            //��������
            Assert.Equal(newColumnName, column.Name);
        }

        [Fact]
        public void AddTask_InColumn_TaskWillBeAdded()
        {
            //����������
            string columnName = "�������� �������";
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column(columnName);
            //��������
            column.AddTask(task);
            //��������
            Assert.Equal(task, column.GetAllTask()[0]);
        }

        [Fact]
        public void GetTask_FromColumn_ReturnTask()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            column.AddTask(task);
            //��������
            ITask? retTask = column.GetTask(task.GUID);
            //��������
            Assert.Equal(task, retTask);
        }

        [Fact]
        public void EditTask_InColumn_TaskWillChange()
        {
            //����������
            string newTaskName = "����� ������";
            string newTaskDescription = "����� �������� ������";
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            column.AddTask(task);
            //��������
            column.EditTask(task.GUID, newTaskName, newTaskDescription, TaskPriority.High);
            //��������
            ITask? retTask = column.GetTask(task.GUID);
            Assert.NotNull(retTask);
            Assert.Equal(newTaskName, retTask.Name);
            Assert.Equal(newTaskDescription, retTask.Description);
            Assert.Equal(TaskPriority.High, retTask.Priority);
        }

        [Fact]
        public void DeleteTask_InColumn_TaskWillDelete()
        {
            //����������
            ITask task = new Task("������", "�������� ������", TaskPriority.Medium);
            IColumn column = new Column("�������� �������");
            column.AddTask(task);
            //��������
            column.DeleteTask(task.GUID);
            //��������
            Assert.Null(column.GetTask(task.GUID));
        }

        [Fact]
        public void GetAllTask_FromColumn_ReturnAllTask()
        {
            //����������
            ITask task1 = new Task("������1", "�������� ������1", TaskPriority.Medium);
            ITask task2 = new Task("������2", "�������� ������2", TaskPriority.Low);
            ITask task3 = new Task("������3", "�������� ������3", TaskPriority.High);
            IColumn column = new Column("�������� �������");
            column.AddTask(task1);
            column.AddTask(task2);
            column.AddTask(task3);
            //��������
            List<ITask> taskList = column.GetAllTask();
            //��������
            Assert.Equal(new List<ITask>() { task1, task2, task3 }, taskList);
        }
    }
}