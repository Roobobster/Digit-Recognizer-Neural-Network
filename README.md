# Digit-Recognizer-Neural-Network


Neural network coded from sratch in C#. Contains a graph visualiser for when training the network to see how it's converging on solution. Also shows how much error there is for each number as it is training to see if it's struggling on specific numbers. 

There is also a visualiser for the weights that allows you to see a sort of weight map, blue is positive weights and red is negative weight values for that pixel. It essentially evaluates the pixels and outputs if it positvely affects the output for that number or negatively. If it's blue it indicates if a pixel is there then it is more likely to output that as the final number label.

Then there is a number grouper that will split numbers that aren't connected and then it will input them into the network seperately and in turn recognize the number as a whole. It does this by making sure to get the image where the digits aren't connected, it then centers the image and scales it the same style as the training data so it is more normalized for the data it has trained on and preform better as a result.




## Example Output
![Example](/readmeImages/snapshot.png)


# Disclaimer


Made for College EPQ Project 2018.
Intended to display knowledge on the subject of neural networks not intended to be a final solution for anything. If used for a final solution a lot more validation and refinement of the algorithms should be implemented otherwise will be too slow to be used at realtime. You will also need to download the MNIST handwritten digit dataset to input into it if you want to train it on something, or any other dataset you want to use. But this project is currently only set up to use the MNIST data format but if you parse other data then it can also still be used in this project.
