
#当前文件夹的路径
CURRENT_DIR = $(shell pwd)
CURRENT_Code_DIR = ../code_Project
#设置当前code工作路径  用于ssh get git
CODE_DIR = $(CURRENT_Code_DIR)/dreamsource

#镜像名称
IMAGE_NAME = dream-datacenter-pro:latest

#Makefile文件地址
CURRENT_FILE= "$(CURRENT_DIR)/Makefile"
   
help:
	@echo "Please use 'make <target>' where <target> is one of"
	@echo "  deploy          deploy ershoufang website with docker"
	@echo "  update          update ershoufang website source code from git"
	@echo "  build           build the docker image containing a ershoufang website"
	@echo "  rebuild         rebuilds the image from scratch without using any cached layers"
	@echo "  network         comfirm the docker used network, if not exist then create"
	@echo "  run             run the built docker image"
	@echo "  bash            starts bash inside a running container."
	@echo "  stop            removes ershoufang websitedocker container and tmp cid file"
	@echo "  clean           removes the tmp cid file on disk"
	@echo " ---------"
	@echo "Docker compose commands"
	@echo "  compose-deploy  deploy containers with docker-compose, param: [env=dev, prd]"
	@echo "  compose-run     starts docker-compose containers, param: [env=dev, prd]"
	@echo "  compose-stop    stops the running docker-compose containers, param: [env=dev, prd]"


deploy: 
	@echo "deploying website with docker..."
	-make -f $(CURRENT_FILE) update
	-make -f $(CURRENT_FILE) cleanFile
	-make -f $(CURRENT_FILE) copyFile 
	-make -f $(CURRENT_FILE) build
	-make -f $(CURRENT_FILE) stop
	-make -f $(CURRENT_FILE) run

  
update:
	@echo "updating git code..."
	@if [ -d $(CODE_DIR) ];	then \
		cd $(CODE_DIR) && git pull; \
	else \
		git clone https://github.com/huijiwanjia/Dream.git --branch dev $(CODE_DIR); \
	fi

stop: 
	@echo "stopping and delete docker image with docker-compose"
	docker-compose -f docker-compose.yml stop; \ 
	 
	docker ps -a | grep "Exited" | awk '{print $1 }' | xargs docker stop; \ 
	docker ps -a | grep "Exited" | awk '{print $1 }' | xargs docker rm; \ 
	docker images | grep none|awk '{print $3 }' | xargs docker rmi

run:
	@echo "create and run docker image..."
	docker-compose -f docker-compose.yml up -d; \	
	 
 
cleanFile: 
	@echo "clean webfile from makefile..."
	$(shell rm -rf ./Dream.DataApi)

copyFile: 
	@echo "copy webfile to docker..."
	$(shell cp -rf ../code_Project/dreamsource/Dream.DataApi/ .) 
 
build: 
	@echo "building docker images..."
	cd $(CURRENT_DIR) && docker build --rm -t $(IMAGE_NAME) .
	

